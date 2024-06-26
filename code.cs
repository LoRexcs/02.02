using System;

class Date
{
    private int day;
    private int month;
    private int year;

    public Date(int day, int month, int year)
    {
        this.day = day;
        this.month = month;
        this.year = year;
    }

    // Перегрузка оператора сложения для добавления дней к дате
    public static Date operator +(Date date, int days)
    {
        DateTime dateTime = new DateTime(date.year, date.month, date.day);
        dateTime = dateTime.AddDays(days);
        return new Date(dateTime.Day, dateTime.Month, dateTime.Year);
    }

    // Перегрузка оператора вычитания для вычисления разницы между двумя датами
    public static int operator -(Date date1, Date date2)
    {
        DateTime dateTime1 = new DateTime(date1.year, date1.month, date1.day);
        DateTime dateTime2 = new DateTime(date2.year, date2.month, date2.day);
        TimeSpan difference = dateTime1 - dateTime2;
        return (int)difference.TotalDays;
    }

    // Перегрузка оператора сравнения для сравнения дат
    public static bool operator >(Date date1, Date date2)
    {
        DateTime dateTime1 = new DateTime(date1.year, date1.month, date1.day);
        DateTime dateTime2 = new DateTime(date2.year, date2.month, date2.day);
        return dateTime1 > dateTime2;
    }

    public static bool operator <(Date date1, Date date2)
    {
        DateTime dateTime1 = new DateTime(date1.year, date1.month, date1.day);
        DateTime dateTime2 = new DateTime(date2.year, date2.month, date2.day);
        return dateTime1 < dateTime2;
    }

    // Перегрузка метода ToString для преобразования в символьную строку
    public override string ToString()
    {
        return $"{day:D2}.{month:D2}.{year:D4}";
    }

    // Статический метод для получения даты из строки
    public static Date Parse(string dateString)
    {
        DateTime dateTime = DateTime.ParseExact(dateString, "dd.MM.yyyy", null);
        return new Date(dateTime.Day, dateTime.Month, dateTime.Year);
    }

    // Метод для получения текущей даты
    public static Date GetCurrentDate() 
    {
        DateTime currentDate = DateTime.Now;
        return new Date(currentDate.Day, currentDate.Month, currentDate.Year);
    }

    // Метод для получения текущего времени
    public static Date GetCurrentTime()
    {
        DateTime currentTime = DateTime.Now;
        return new Date(currentTime.Hour, currentTime.Minute, currentTime.Second);
    }

    // Метод для получения количества дней между двумя датами
    public static int GetDaysInInterval(Date startDate, Date endDate)
    {
        TimeSpan interval = new DateTime(endDate.year, endDate.month, endDate.day) -
                            new DateTime(startDate.year, startDate.month, startDate.day);
        return (int)interval.TotalDays;
    }

    // Метод для получения количества месяцев между двумя датами
    public static int GetMonthsInInterval(Date startDate, Date endDate)
    {
        int monthsApart = ((endDate.year - startDate.year) * 12) + (endDate.month - startDate.month);
        return Math.Abs(monthsApart);
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите день первой даты: ");
        int day1 = int.Parse(Console.ReadLine());

        Console.Write("Введите месяц первой даты: ");
        int month1 = int.Parse(Console.ReadLine());

        Console.Write("Введите год первой даты: ");
        int year1 = int.Parse(Console.ReadLine());

        Console.Write("Введите день второй даты: ");
        int day2 = int.Parse(Console.ReadLine());

        Console.Write("Введите месяц второй даты: ");
        int month2 = int.Parse(Console.ReadLine());

        Console.Write("Введите год второй даты: ");
        int year2 = int.Parse(Console.ReadLine());

        Date date1 = new Date(day1, month1, year1);
        Date date2 = new Date(day2, month2, year2);

        // Пример использования операторов
        Date result1 = date1 + 7;
        int difference = date2 - date1;
        bool isGreater = date2 > date1;

        Console.WriteLine($"Дата 1: {date1}");
        Console.WriteLine($"Дата 2: {date2}");
        Console.WriteLine($"Дата 1 + 7 дней: {result1}");
        Console.WriteLine($"Разница между датами: {difference} дней");
        Console.WriteLine($"Дата 2 > Дата 1: {isGreater}");

        // Пример использования статического метода
        string dateString = "20.06.2024";
        Date parsedDate = Date.Parse(dateString);
        Console.WriteLine($"Дата из строки: {parsedDate}");

        // Пример использования новых методов
        Date currentDate = Date.GetCurrentDate(); //Добавлены новые возможности кода
        Date currentTime = Date.GetCurrentTime();

        Console.WriteLine($"Текущая дата: {currentDate}");
        Console.WriteLine($"Текущее время: {currentTime}");

        Date startDate = new Date(1, 1, 2024);
        Date endDate = new Date(31, 12, 2024);

        int daysInInterval = Date.GetDaysInInterval(startDate, endDate);
        int monthsInInterval = Date.GetMonthsInInterval(startDate, endDate);

        Console.WriteLine($"Дней в интервале: {daysInInterval}");
        Console.WriteLine($"Месяцев в интервале: {monthsInInterval}");
    }
}
