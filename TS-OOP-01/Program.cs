namespace TS_OOP_01
{
    internal class Program
    {


        static void ShowMainMenu()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("=== SKY WINGS FLIGHT MANAGEMENT SYSTEM ===");
            Console.WriteLine("*******************************************");
            Console.WriteLine("1 - Register New Passenger");
            Console.WriteLine("2 - View All Passengers");
            Console.WriteLine("3 - Book a Flight Ticket");
            Console.WriteLine("4 - View Booking Details");
            Console.WriteLine("5 - Update a Booking");
            Console.WriteLine("6 - Cancel a Ticket");
            Console.WriteLine("7 - Passenger Check-In");
            Console.WriteLine("8 - Board Passengers");
            Console.WriteLine("9 - Generate Flight Manifest");
            Console.WriteLine("10 - Manage Waitlist & Seat Assignment");
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
                    //CaseRegisterPassenger();
                    //break;

                    //case 2:
                    //CaseViewPassengers();
                    //break;

                    //case 3:
                    //CaseBookFlight();
                    //break;

                    //case 4:
                    //CaseViewBooking();
                    //break;

                    //case 5:
                    //UpdateBooking();
                    //break;

                    //case 6:
                    //CancelBooking();
                    //break;

                    //case 7:
                    //PassengerCheckIn();
                    //break;

                    //case 8:
                    //BoardPassengers();
                    //break;

                    //case 9:
                    //GenerateManifest();
                    //break;   // you’ll define this

                    //case 10:
                    //ManageWaitlist();
                    //break;    // you’ll define this
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
