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

        static void AddNewRoom(List<Room> rooms)
        {
            Console.Write("Enter Room Number: ");
            int roomNumber = int.Parse(Console.ReadLine());

            // Check if room already exists
            if (rooms.Any(r => r.RoomNumber == roomNumber))
            {
                Console.WriteLine("Error: Room number already exists.");
                return;
            }

            Console.Write("Enter Room Type (Single/Double/Suite): ");
            string roomType = Console.ReadLine();

            Console.Write("Enter Price Per Night: ");
            double price = double.Parse(Console.ReadLine());

            // Validate positive price
            if (price <= 0)
            {
                Console.WriteLine("Price must be greater than 0.");
                return;
            }

            Room newRoom = new Room
            {
                RoomNumber = roomNumber,
                RoomType = roomType,
                PricePerNight = price,
                IsAvailable = true
            };

            rooms.Add(newRoom);

            Console.WriteLine("\nRoom added successfully!");
            Console.WriteLine($"Room Number : {newRoom.RoomNumber}");
            Console.WriteLine($"Room Type   : {newRoom.RoomType}");
            Console.WriteLine($"Price       : OMR {newRoom.PricePerNight:F2}");
            Console.WriteLine($"Available   : {newRoom.IsAvailable}");
            Console.WriteLine($"Total Rooms : {rooms.Count}");
        }

        static void Main(string[] args)
        {
            List<Room> rooms = new List<Room>()
            {
            new Room { RoomNumber = 101, RoomType = "Single", PricePerNight = 25, IsAvailable = true },
            new Room { RoomNumber = 102, RoomType = "Double", PricePerNight = 40, IsAvailable = true },
            new Room { RoomNumber = 103, RoomType = "Suite", PricePerNight = 80, IsAvailable = true },
            new Room { RoomNumber = 104, RoomType = "Single", PricePerNight = 30, IsAvailable = true },
            new Room { RoomNumber = 105, RoomType = "Double", PricePerNight = 45, IsAvailable = true },
            new Room { RoomNumber = 106, RoomType = "Suite", PricePerNight = 90, IsAvailable = true }
        };
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
                        AddNewRoom(rooms);
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