using System;

namespace Elevator
{
    public class Building
    {

        private int NumberOfFloors { get; set; }
        private string[] Elevators { get; set; }

        public Building(int numberOfFloors, String[] elevators)
        {
            this.NumberOfFloors = numberOfFloors;
            this.Elevators = elevators;

        }

        public String RequestElevator()
        {
            throw new NotImplementedException();
        }

        public String RequestElevator(int requestFloor)
        {
            throw new NotImplementedException();
        }

        public void StopAt(string idElevator, int floor)
        {
            throw new NotImplementedException();
        }

        public void Move(string idElevator, string direction)
        {
            throw new NotImplementedException();
        }
    }
}
