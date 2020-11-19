using NUnit.Framework;
using Elevator;

namespace ElevatorTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void the_closestelevator_to_floor_zero_should_arrive_first()
        {
            int numberOfFloors = 10;
            Building building = new Building(numberOfFloors, new string[] {"id1:1", "id2:6" }); // "[elevator_id]:[elevator_current_floor]"

            string idOfFirstAvailableElevator = building.RequestElevator(); // a request is by default from floor 0.

            Assert.AreEqual("id1", idOfFirstAvailableElevator);
        }

        [Test]

        public void elevators_going_up_arrive_last_to_floor_zero()
        {
            Building building = new Building(10, new string[] { "id1:1", "id2:6" });
            building.Move("id1", "UP"); // tell the elevator "id1" to move "UP".

            string idOfFirstAvailableElevator = building.RequestElevator();

            Assert.AreEqual("id2", idOfFirstAvailableElevator);
        }

        [Test]

        public void elevators_going_down_should_arrive_to_floor_zero_before_those_going_up()
        {
            Building building = new Building(10, new string[] { "id1:1", "id2:6" });
            building.Move("id1", "UP");
            building.Move("id2", "DOWN");

            string idOfFirstAvailableElevator = building.RequestElevator();

            Assert.AreEqual("id2", idOfFirstAvailableElevator);
        }

        [Test]

        public void elevators_going_down_should_be_compared_to_those_resting()
        {
            Building building = new Building(10, new string[] { "id1:1", "id2:6", "id3:5" });
            building.Move("id1", "UP");
            building.Move("id2", "DOWN");

            string idOfFirstAvailableElevator = building.RequestElevator();

            Assert.AreEqual("id3", idOfFirstAvailableElevator);
        }

        [Test]
        public void elevators_going_down_and_not_stopping_should_arrive_first_to_floor_zero()
        {
            Building building = new Building(10, new string[] { "id1:1", "id2:6", "id3:3" });
            building.Move("id1", "UP");
            building.Move("id2", "DOWN");
            building.Move("id3", "DOWN");
            building.StopAt("id3", 2); // request elevator "id3" to stop at level 2.

            string idOfFirstAvailableElevator = building.RequestElevator();

            Assert.AreEqual("id2", idOfFirstAvailableElevator);
        }

        [Test]
        public void can_request_elevator_in_middle_of_building()
        {
            Building building = new Building(10, new string[] { "id1:1", "id2:6" });

            string idOfFirstAvailableElevator = building.RequestElevator(5); // the request is made at the 5th floor

            Assert.AreEqual("id2", idOfFirstAvailableElevator); // "id2" is the closest elevator to 5th floor
        }





    }
}