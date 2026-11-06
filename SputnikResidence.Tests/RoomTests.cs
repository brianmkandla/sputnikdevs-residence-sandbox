using SputnikDevs.Residence.SandboxApi.Domain.Entities;

namespace SputnikResidence.Tests;

public class RoomTests
{
    [Fact]
    public void AvailableSpots_PartiallyOccupied_ReturnsRemainingSpots()
    {
        var room = new Room { Capacity = 4 };
        room.Students.Add(new Student());

        var result = room.AvailableSpots;

        Assert.Equal(3, result);
    }

    [Fact]
    public void AvailableSpots_FullyOccupied_ReturnsZero()
    {
        var room = new Room { Capacity = 4 };
        for (int i = 0; i < 4; i++)
            room.Students.Add(new Student());

        var result = room.AvailableSpots;

        Assert.Equal(0, result);
    }

    [Fact]
    public void AvailableSpots_OverOccupied_ReturnsZeroNotNegative()
    {
        var room = new Room { Capacity = 7 };
        for (int i = 0; i < 7; i++)
            room.Students.Add(new Student());
        
        var result = room.AvailableSpots;

        Assert.Equal(0, result);
    }
}
