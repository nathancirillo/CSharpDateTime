namespace LearnDateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            //Observations: date will never be null. 

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

            Console.WriteLine($"Data formatada: {formattedOne}.");
            Console.WriteLine($"Data formatada: {formattedTwo}.");
            Console.WriteLine($"Data formatada: {formattedThree}.");
            Console.WriteLine($"Data formatada: {formattedFour}.");
            Console.WriteLine($"Data formatada: {formattedFive}.");
            Console.WriteLine($"Data formatada: {formattedSix}.");
            Console.WriteLine($"Data formatada: {formattedSeven}.");
            Console.WriteLine($"Data formatada: {formattedEight}.");                  
        }
    }
}