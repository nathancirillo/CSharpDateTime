using System.Globalization;

namespace LearnDateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            //Observations: date will never be null. this will occur if we have a nullable type.  

            //create a date with default value: how it's a struct it always has a default value.              
            System.Console.WriteLine($"Data e hora padrão: {new DateTime()}.");   

            //it's possible to obtain the current date and time
            System.Console.WriteLine($"Data e hora atual: {DateTime.Now}.");   

            //sometimes we need to create a date passing year, month, day, hour, minute, second, millisecond.
            var personalitedDate = new DateTime(1990,09,20,12,30,00);
            System.Console.WriteLine($"Data personalizada: {personalitedDate}.");

            //it's interesting to know that you can take any part of the date separated 
            System.Console.WriteLine($"Ano: {personalitedDate.Year}.");
            System.Console.WriteLine($"Mês: {personalitedDate.Month}.");
            System.Console.WriteLine($"Dia: {personalitedDate.Day}.");
            System.Console.WriteLine($"Hora: {personalitedDate.Hour}.");
            System.Console.WriteLine($"Minuto: {personalitedDate.Minute}.");
            System.Console.WriteLine($"Segundo: {personalitedDate.Second}.");

            //another interesting date properties are: 
            System.Console.WriteLine($"Dia da semana: {personalitedDate.DayOfWeek}.");
            System.Console.WriteLine($"Dia do ano: {personalitedDate.DayOfYear}.");

            //to format a date we can use string.Format() method. 
            //Y or y -> show year
            //M -> show month
            //m -> show minute
            //d -> show day 
            //h -> show hour
            //s -> show second
            var currentDate = DateTime.Now;
            var formattedOne = string.Format("{0:yyyy}", currentDate); 
            var formattedTwo = string.Format("{0:yyy}", currentDate); 
            var formattedThree = string.Format("{0:yy}", currentDate); 
            var formattedFour = string.Format("{0:y}", currentDate);
            var formattedFive = string.Format("{0:M}", currentDate); 
            var formattedSix = string.Format("{0:MM}", currentDate);
            var formattedSeven = string.Format("{0:yyyy-MM-dd}", currentDate);
            var formattedEight = string.Format("{0:dd/MM/yyyy hh:mm:ss}", currentDate);
            var formattedNine = string.Format("{0:yyyy * MM * dd}", currentDate); 

            Console.WriteLine($"Data formatada: {formattedOne}.");
            Console.WriteLine($"Data formatada: {formattedTwo}.");
            Console.WriteLine($"Data formatada: {formattedThree}.");
            Console.WriteLine($"Data formatada: {formattedFour}.");
            Console.WriteLine($"Data formatada: {formattedFive}.");
            Console.WriteLine($"Data formatada: {formattedSix}.");
            Console.WriteLine($"Data formatada: {formattedSeven}.");
            Console.WriteLine($"Data formatada: {formattedEight}.");   
            Console.WriteLine($"Data formatada: {formattedNine}.");    

            //the are some predefined formatters:   
            
            //only short time. use T to long time.    
            var shortTime = string.Format("{0:t}", DateTime.Now);
            System.Console.WriteLine(shortTime);    

            //only short date. use D to long date. 
            var shortDate = string.Format("{0:d}", DateTime.Now);
            System.Console.WriteLine(shortDate);    

            //combining date and hour.   
            var dateHour = string.Format("{0:g}", DateTime.Now);
            System.Console.WriteLine(dateHour);     

            //we can use RFC 1123. Standard used in many systems. (r ou R)   
            var standard = string.Format("{0:r}", DateTime.Now);
            System.Console.WriteLine(standard); 

            //to use a sortible datatime we can use the s option. used in json.   
            var sortibleDataTime = string.Format("{0:s}", DateTime.Now);
            System.Console.WriteLine(sortibleDataTime); 

            //the universal datetime can be expressed with u option          
            var universalDateTime = string.Format("{0:u}", DateTime.Now);
            System.Console.WriteLine(universalDateTime); 


            //ADD DAYS, MONTHS AND YEARS TO A DATE: 
            //avoid to use +1 in these values, because we don't have control of the date.
            var myDate = DateTime.Now; 

            //add days to a date.
            var addDays = myDate.AddDays(10);
            System.Console.WriteLine(addDays);

             //add months to a date.
            var addMonths = myDate.AddMonths(8);
            System.Console.WriteLine(addMonths);

            //add years to a date.
            var addYears = myDate.AddYears(4);
            System.Console.WriteLine(addYears);


            //COMPARING DATES
            //Bear in mind that we can use the operator ==, but in some cases this will not work. 
            //In the follow example the first date is milliseconds different from the other. 
            //We can use all the operators: <, >, <=, >= e == to compare dates.
            var firstDate = DateTime.Now; 
            var situation = firstDate == DateTime.Now ? "Equal" : "Different";
            System.Console.WriteLine(situation);

            //One way to solve this is been more especific. For example: taking only the date. 
            var newSituation = firstDate.Date == DateTime.Now.Date ? "Equal" : "Different";
            System.Console.WriteLine(newSituation);

            //ANOTHER THING TO LEARN IS GLOBALIZATION. 
            //we need to know where the user is to show the correct date, for example.
            //instead of use string.Format() is possible to use ToString() method.

            //we can use the cultureinfo class to get the correct date.
            var br = new CultureInfo("pt-BR");
            var pt = new CultureInfo("pt-PT");
            var en = new CultureInfo("en-US");
            var de = new CultureInfo("de-DE");
            var current = CultureInfo.CurrentCulture;
            System.Console.WriteLine(DateTime.Now);
            System.Console.WriteLine(DateTime.Now.ToString("D",en));

            // TIMEZONE: important to know the timezone of the user. Recommended for globalized applications.
            // Your application can be around the world. So it's recommended to use UtcNow (global datetime).
            // After depending on the timezone, you apply the correct CultureInfo.
            System.Console.WriteLine($"Data do servidor: {DateTime.Now}");
            System.Console.WriteLine($"Data universal: {DateTime.UtcNow}"); 
            System.Console.WriteLine($"Data universal ajustado com a data da máquina local: {DateTime.UtcNow.ToLocalTime()}");
            // In the following example i show how to take a specific TimeZoneInfo
            var timeZoneAustralia = TimeZoneInfo.FindSystemTimeZoneById("Pacific/Auckland");
            System.Console.WriteLine(timeZoneAustralia);
            // Now i add the timezone in the UtcNow datetime 
            var dataAustralia = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneAustralia);
            System.Console.WriteLine(dataAustralia);

            //taking all TimeZones registered in the system. May vary according to the system.
            foreach(var timezone in TimeZoneInfo.GetSystemTimeZones())
            {
                System.Console.WriteLine($"ID = {timezone.Id}");
                System.Console.WriteLine($"TIMEZONE = {timezone}");
                System.Console.WriteLine($"DATA COM TIMEZONE = {TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timezone)}");
                System.Console.WriteLine("-------------------------------------------------------------------------------------");
            }


            //TIMESPAN: unity universal to measure time. This is not exclusivy of .NET.
            
            //this will be only zeroes 
            System.Console.WriteLine(new TimeSpan());

            //nanoseconds 
            System.Console.WriteLine(new TimeSpan(1));
            
            //hour, minutes and seconds
            System.Console.WriteLine(new TimeSpan(4, 20, 32));

            //day, hour, minutes and seconds
            System.Console.WriteLine(new TimeSpan(15, 16, 11, 40));

            //day, hour, minutes, seconds and milliseconds
            System.Console.WriteLine(new TimeSpan(15, 16, 11, 40, 20));


            //ANOTHER INTERESTING METHODS. 

            //take the quantity days in a specific year and month
            System.Console.WriteLine(DateTime.DaysInMonth(2022, 7));

            //day is weekend or not.
            var todayIsWeekend = IsWeekeend(DateTime.Now.DayOfWeek);
            System.Console.WriteLine($"Today is weekend: {todayIsWeekend}");

            //is day light saving time or not (horário de verão).
            System.Console.WriteLine(DateTime.Now.IsDaylightSavingTime());
        }

        static bool IsWeekeend(DayOfWeek today)
        {
            return today == DayOfWeek.Saturday || today == DayOfWeek.Sunday;
        }
    }
}