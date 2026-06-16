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

            if (rooms.Any(r => r.RoomNumber == roomNumber))
            {
                Console.WriteLine("Error: Room number already exists.");
                return;
            }

            List<string> roomTypes = new List<string> { "Single", "Double", "Suite" };
            string roomType;

            do
            {
                Console.Write("Enter Room Type (Single/Double/Suite): ");
                roomType = Console.ReadLine();

                if (!roomTypes.Any(r => r.Equals(roomType, StringComparison.OrdinalIgnoreCase)))
                    Console.WriteLine("Invalid room type.");
            }
            while (!roomTypes.Any(r => r.Equals(roomType, StringComparison.OrdinalIgnoreCase)));

            roomType = roomTypes.First(r => r.Equals(roomType, StringComparison.OrdinalIgnoreCase));

            Console.Write("Enter Price Per Night: ");
            double price = double.Parse(Console.ReadLine());

            if (price <= 0)
            {
                Console.WriteLine("Price must be greater than 0.");
                return;
            }

            rooms.Add(new Room
            {
                RoomNumber = roomNumber,
                RoomType = roomType,
                PricePerNight = price,
                IsAvailable = true
            });

            Console.WriteLine("\nRoom added successfully!");
            Console.WriteLine($"Room Number: {roomNumber}");
            Console.WriteLine($"Room Type: {roomType}");
            Console.WriteLine($"Price: OMR {price:F2}");
            Console.WriteLine($"Total Rooms: {rooms.Count}");
        }
        static void RegisterGuest(List<Guest> guests)
        {
            Console.Write("Enter Guest Name: ");
            string guestName = Console.ReadLine();

            string checkInDate;
            DateTime date;
            do
            {
                Console.Write("Enter Check-In Date (dd/MM/yyyy): ");
                checkInDate = Console.ReadLine();

                if (!DateTime.TryParseExact(checkInDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out date))
                    Console.WriteLine("Invalid date format.");
            }
            while (!DateTime.TryParseExact(checkInDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out date));

            Console.Write("Enter Total Nights: ");
            int totalNights = int.Parse(Console.ReadLine());

            if (totalNights <= 0)
            {
                Console.WriteLine("Number of nights must be greater than 0.");
                return;
            }

            string guestId = "G" + (guests.Count + 1).ToString("000");

            guests.Add(new Guest
            {
                GuestId = guestId,
                GuestName = guestName,
                RoomNumber = "Not Assigned",
                CheckInDate = checkInDate,
                TotalNights = totalNights
            });

            Guest newGuest = guests.Last();

            Console.WriteLine("\nGuest Registered Successfully!");
            Console.WriteLine($"Guest ID: {newGuest.GuestId}");
            Console.WriteLine($"Guest Name: {newGuest.GuestName}");
            Console.WriteLine($"Check-In Date: {newGuest.CheckInDate}");
            Console.WriteLine($"Total Nights: {newGuest.TotalNights}");
            Console.WriteLine($"Room Number: {newGuest.RoomNumber}");
        }
        static void BookRoom(List<Room> rooms, List<Guest> guests)
        {
            Console.Write("Enter Guest ID: ");
            string guestId = Console.ReadLine();

            Guest guest = guests.FirstOrDefault(g => g.GuestId == guestId);

            if (guest == null)
            {
                Console.WriteLine("Guest not found.");
                return;
            }

            Console.WriteLine("\nAvailable Rooms:");
            foreach (Room r in rooms.Where(r => r.IsAvailable))
            {
                Console.WriteLine($"{r.RoomNumber} - {r.RoomType} - OMR {r.PricePerNight:F2}");
            }

            if (!rooms.Any(r => r.IsAvailable))
            {
                Console.WriteLine("No rooms available.");
                return;
            }

            Console.Write("\nEnter Room Number: ");
            int roomNumber = int.Parse(Console.ReadLine());

            Room room = rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);

            if (room == null)
            {
                Console.WriteLine("Room not found.");
                return;
            }

            if (!room.IsAvailable)
            {
                Console.WriteLine("Room is already booked.");
                return;
            }

            guest.RoomNumber = room.RoomNumber.ToString();
            room.IsAvailable = false;

            Console.WriteLine("\nBooking Successful!");
            Console.WriteLine($"Guest Name: {guest.GuestName}");
            Console.WriteLine($"Room Number: {room.RoomNumber}");
            Console.WriteLine($"Room Type: {room.RoomType}");
            Console.WriteLine($"Price/Night: OMR {room.PricePerNight:F2}");
            Console.WriteLine($"Total Nights: {guest.TotalNights}");
            Console.WriteLine($"Total Cost: OMR {guest.CalculateTotalCost(rooms):F2}");
        }
        static void SearchRooms(List<Room> rooms)
        {
            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine("************Search Rooms**********");
                Console.WriteLine("1.Available Rooms");
                Console.WriteLine("2.Filter by Type");
                Console.WriteLine("3.Filter by Price");
                Console.WriteLine("4.Room Statistics");
                Console.WriteLine("0.Back");
                Console.Write("Choice: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        foreach (Room r in rooms.Where(r => r.IsAvailable).OrderBy(r => r.PricePerNight))
                            r.DisplayRoom();
                        break;

                    case "2":
                        Console.Write("Enter Type: ");
                        string type = Console.ReadLine();

                        foreach (Room r in rooms.Where(r => r.RoomType.Equals(type, StringComparison.OrdinalIgnoreCase)))
                            r.DisplayRoom();
                        break;

                    case "3":
                        Console.Write("Enter Maximum Price: ");
                        double maxPrice = double.Parse(Console.ReadLine());

                        foreach (Room r in rooms.Where(r => r.IsAvailable && r.PricePerNight <= maxPrice)
                                               .OrderBy(r => r.PricePerNight))
                            r.DisplayRoom();
                        break;

                    case "4":
                        Console.WriteLine($"Total Rooms: {rooms.Count()}");
                        Console.WriteLine($"Available Rooms: {rooms.Count(r => r.IsAvailable)}");
                        Console.WriteLine($"Average Price: OMR {rooms.Average(r => r.PricePerNight):F2}");
                        Console.WriteLine($"Lowest Price: OMR {rooms.Min(r => r.PricePerNight):F2}");
                        Console.WriteLine($"Highest Price: OMR {rooms.Max(r => r.PricePerNight):F2}");
                        break;
                    case "0":
                        exit=true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                if (exit == false)
                {
                    Console.WriteLine(" Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }

            }
        }
        static void ShowStatistics(List<Room> rooms, List<Guest> guests)
        {
            Console.WriteLine($"Total Guests: {guests.Count()}");
            Console.WriteLine($"Guests With Bookings: {guests.Count(g => g.RoomNumber != "Not Assigned")}");
            Console.WriteLine($"Booked Rooms: {rooms.Count(r => !r.IsAvailable)}");

            if (guests.Any(g => g.RoomNumber != "Not Assigned"))
            {
                Console.WriteLine($"Average Stay: {guests.Where(g => g.RoomNumber != "Not Assigned").Average(g => g.TotalNights):F2} nights");

                Console.WriteLine("\nTop 3 Highest Paying Guests:");
                foreach (Guest g in guests.Where(g => g.RoomNumber != "Not Assigned").OrderByDescending(g => g.CalculateTotalCost(rooms)).Take(3))
                    Console.WriteLine($"{g.GuestName} - OMR {g.CalculateTotalCost(rooms):F2}");

                Console.WriteLine("\nGuest Summaries:");
                foreach (string s in guests.Where(g => g.RoomNumber != "Not Assigned").Select(g => $"{g.GuestName} | Room {g.RoomNumber} | {g.TotalNights} nights"))
                    Console.WriteLine(s);
            }
            else
                Console.WriteLine("No bookings available.");

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

                        case 2:
                            RegisterGuest(guests);
                            break;

                        case 3:
                            BookRoom(rooms, guests);
                            break;

                        case 4:
                            SearchRooms(rooms);
                            break;

                    case 5:
                        ShowStatistics(rooms, guests);
                        break;

                    //case 6: 
                    //    CaseFilterCheapRooms(); 
                    //    break;

                    //case 7: 
                    //    CaseSortRooms(); 
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
