namespace TS_OOP_01
{
    internal class Program
    {
        class Room
        {
            public int RoomNumber;
            public string RoomType;
            public double PricePerNight;
            public bool IsAvailable;

            public void DisplayRoom()
            {
                Console.WriteLine($"{RoomNumber} | {RoomType} | OMR {PricePerNight:F2} | {(IsAvailable ? "Available" : "Booked")}");
            }
        }
        class Guest
        {
            public string GuestId;
            public string GuestName;
            public string RoomNumber = "Not Assigned";
            public string CheckInDate;
            public int TotalNights;

            public double CalculateTotalCost(List<Room> rooms)
            {
                var room = rooms.FirstOrDefault(r => r.RoomNumber.ToString() == RoomNumber);
                if (room == null)
                {
                    return 0;
                }

                return room.PricePerNight * TotalNights;
            }
        }
        static void ShowMainMenu()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("=== HOTEL MANAGEMENT SYSTEM ===");
            Console.WriteLine("*******************************************");
            Console.WriteLine("1 - Add New Room");
            Console.WriteLine("2 - View All Rooms");
            Console.WriteLine("3 - Search Available Rooms");
            Console.WriteLine("4 - Book a Room");
            Console.WriteLine("5 - Release a Room");
            Console.WriteLine("6 - Filter Cheap Rooms (< 50 OMR)");
            Console.WriteLine("7 - Sort Rooms by Price");
            Console.WriteLine("8 - Count & Average Room Price");
            Console.WriteLine("9 - Remove Room");
            Console.WriteLine("10 - LINQ Chaining Example");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("*******************************************");
        }

        static void Main(string[] args)
        {
            List<Room> rooms = new List<Room>();
            List<Guest> guests = new List<Guest>();
            int choice;
            do
            {
                ShowMainMenu();
                Console.Write("Enter choice: ");
                if (!int.TryParse(Console.ReadLine(), out choice)) choice = -1;

                switch (choice)
                {
                    case 1:
                        CaseAddRoom();
                        break;

                    //case 2: 
                    //    CaseViewRooms(); 
                    //    break;

                    //case 3: 
                    //    CaseSearchAvailableRooms(); 
                    //    break;

                    //case 4: 
                    //    CaseBookRoom(); 
                    //    break;

                    //case 5: 
                    //    CaseReleaseRoom(); 
                    //    break;

                    //case 6: 
                    //    CaseFilterCheapRooms(); 
                    //    break;

                    //case 7: 
                    //    CaseSortRooms(); 
                    //    break;

                    //case 8: 
                    //    CaseCountAndAverage(); 
                    //    break;

                    //case 9: 
                    //    CaseRemoveRoom(); 
                    //    break;

                    //case 10: 
                    //    CaseLinqChaining(); 
                    //    break;

                    case 0: 
                        Console.WriteLine("Exiting system..."); 
                        break;

                    default: 
                        Console.WriteLine("Invalid choice."); 
                        break;
                }

                if (choice != 0)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (choice != 0);
        }
    }
}