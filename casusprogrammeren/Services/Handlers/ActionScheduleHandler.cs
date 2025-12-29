using System.Text;
using casusprogrammeren.utils;

namespace casusprogrammeren.Services.Handlers;

public class ActionScheduleHandler
{
    public static string HandleScheduleRequests()
    {
        var sb = new StringBuilder();
        var jsonUtil = new JsonUtil();
        
        var schedules = jsonUtil.Deserialize<ScheduleRequests>();
        var rooms = jsonUtil.Deserialize<Rooms>();

        if (schedules == null || schedules.Count == 0)
        {
            return "No schedule requests found.";
        }

        if (rooms == null || rooms.Count == 0)
        {
            return "No rooms available.";
        }

        var sortedSchedules = 
            schedules.OrderBy(scheduleRequests => scheduleRequests.RequestedTime).ToList();
        var scheduledRequests = new List<ScheduledRequests>();

        foreach (var schedule in sortedSchedules)
        {
            var assigned = TryScheduleRequest(schedule, scheduledRequests, rooms);

            if (assigned != null)
            {
                scheduledRequests.Add(assigned);
                sb.AppendLine($"Scheduled {schedule.RequestedBy}:");
                sb.AppendLine($"Room: {assigned.ScheduledRoom}");
                sb.AppendLine($"Time: {assigned.ScheduledStartTime:yyyy-MM-dd HH:mm} - {assigned.ScheduledEndTime:HH:mm}");
                sb.AppendLine();
            }
            else
            {
                sb.AppendLine($"Could not schedule {schedule.RequestedBy}");
                sb.AppendLine($"Requested: {schedule.DurationMinutes} minutes");
                sb.AppendLine($"Window: {schedule.TimePreferences.Earliest:HH:mm} - {schedule.TimePreferences.Latest:HH:mm}");
                sb.AppendLine();
            }
        }

        jsonUtil.Serialize(scheduledRequests, "Schedule.json");
        sb.AppendLine($"Scheduled {scheduledRequests.Count} of {schedules.Count} requests");
        
        return sb.ToString();
    }

    private static ScheduledRequests TryScheduleRequest(ScheduleRequests request, List<ScheduledRequests> existing, List<Rooms> availableRooms)
    {
        // Try preferred rooms first
        foreach (var preferredRoomCode in request.Preferences)
        {
            var roomExists = availableRooms.Any(r => r.Code == preferredRoomCode);
            if (!roomExists) continue;
            
            var scheduled = TryScheduleInRoom(request, preferredRoomCode, existing);
            if (scheduled != null) return scheduled;
        }

        // Try all rooms from the Rooms.json that are not in preferences
        var alternativeRooms = availableRooms
            .Where(rooms => rooms.Code != null && !request.Preferences.Contains(rooms.Code))
            .Select(rooms => rooms.Code)
            .Distinct()
            .ToList();

        foreach (var roomCode in alternativeRooms)
        {
            if (roomCode == null) continue;
            var scheduled = TryScheduleInRoom(request, roomCode, existing);
            if (scheduled != null) return scheduled;
        }

        return null;
    }

    private static ScheduledRequests TryScheduleInRoom(ScheduleRequests request, string roomCode, List<ScheduledRequests> existing)
    {
        var currentTime = request.TimePreferences.Earliest;
        var latestTime = request.TimePreferences.Latest;
        var endTime = currentTime.AddMinutes(request.DurationMinutes);

        // Check if the request can be done in the time window
        if (endTime > latestTime)
        {
            return null;
        }

        // Try to find any non-conflicting slot
        while (endTime <= latestTime)
        {
            bool hasConflict = existing.Any(e =>
                e.ScheduledRoom == roomCode &&
                e.ScheduledStartTime < endTime &&
                e.ScheduledEndTime > currentTime);

            if (!hasConflict)
            {
                return new ScheduledRequests
                {
                    Id = request.Id.ToString(),
                    ScheduledRoom = roomCode,
                    ScheduledStartTime = currentTime,
                    ScheduledEndTime = endTime
                };
            }

            currentTime = currentTime.AddMinutes(15);
            endTime = currentTime.AddMinutes(request.DurationMinutes);
        }

        return null;
    }
}
