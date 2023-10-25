using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Добро пожаловать в Продуктовый супермаркет!");

        Console.WriteLine("Введите текущее время в формате HH:mm (например, 10:30):");
        string timeStr = Console.ReadLine();
        if (!DateTime.TryParse(timeStr, out DateTime currentTime))
        {
            Console.WriteLine("Некорректный формат времени. Программа завершена.");
            return;
        }

        Console.WriteLine("Выберите продукты для покупки (введите 'завершить' для завершения):");

        double totalCost = 0.0;
        string product;

        do
        {
            Console.Write("Введите название продукта: ");
            product = Console.ReadLine();

            if (product.ToLower() == "завершить")
                break;

            Console.Write("Введите цену продукта: ");
            if (!double.TryParse(Console.ReadLine(), out double price))
            {
                Console.WriteLine("Некорректная цена. Продукт не учтен.");
                continue;
            }

            totalCost += price;
        } while (true);

        double discount = 0.0;
        if (currentTime.Hour >= 8 && currentTime.Hour < 12)
        {
            discount = totalCost * 0.05; // 5% скидка с 8:00 до 12:00
        }

        double finalCost = totalCost - discount;

        Console.WriteLine($"Итоговая стоимость без скидки: {totalCost:C}");
        Console.WriteLine($"Скидка (5%): {discount:C}");
        Console.WriteLine($"Итоговая стоимость со скидкой: {finalCost:C}");

        Console.WriteLine("Спасибо за покупки! Приходите еще!");
    }
}
