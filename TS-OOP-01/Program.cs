namespace TS_OOP_01
{
    internal class Program
    {
        public class Room
        {
            // Properties
            public int RoomId { get; set; }
            public string RoomType { get; set; }   //  Single, Double, Suite
            public double PricePerNight { get; set; }
            public bool IsAvailable { get; set; }

            // Constructor
            public Room(int id, string type, double price, bool available = true)
            {
                RoomId = id;
                RoomType = type;
                PricePerNight = price;
                IsAvailable = available;
            }

            // Methods
            public void BookRoom()
            {
                if (IsAvailable)
                {
                    IsAvailable = false;
                    Console.WriteLine("Room booked successfully.");
                }
                else
                {
                    Console.WriteLine("Room is already booked.");
                }
            }

            public void ReleaseRoom()
            {
                IsAvailable = true;
                Console.WriteLine("Room released and now available.");
            }

            public void DisplayRoom()
            {
                string status = IsAvailable ? "Available" : "Booked";
                Console.WriteLine($"Room {RoomId} | {RoomType} | {PricePerNight} OMR | {status}");
            }
        }

        //    public void BookRoom()
        //    {
        //        if (IsAvailable)
        //        {
        //            IsAvailable = false;
        //            Console.WriteLine($"Room {RoomId} booked successfully.");
        //        }
        //        else
        //        {
        //            Console.WriteLine($"Room {RoomId} is already booked.");
        //        }
        //    }

        //    public void ReleaseRoom()
        //    {
        //        IsAvailable = true;
        //        Console.WriteLine($"Room {RoomId} is now available.");
        //    }

        //    public override string ToString()
        //    {
        //        string status = IsAvailable ? "Available" : "Booked";
        //        return $"Room {RoomId} | Type: {RoomType} | Price: {PricePerNight} | Status: {status}";
        //    }
        //}

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
            int choice;
            do
            {
                ShowMainMenu();
                Console.Write("Enter choice: ");
                if (!int.TryParse(Console.ReadLine(), out choice)) choice = -1;

                switch (choice)
                {
                    //case 1: 
                    //    CaseAddRoom(); 
                    //    break;

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