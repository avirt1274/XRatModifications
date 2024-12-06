using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        int numberOfThreads = Environment.ProcessorCount; // Получаем количество логических процессоров
        int targetLoad = 90; // Целевая нагрузка - 90%

        // Вычисляем, сколько процентов времени процессор должен быть занят
        int workTime = 100; // Время работы в миллисекундах
        int idleTime = (100 - targetLoad); // Время бездействия

        // Статический Random, чтобы избежать многократного создания в потоках
        Random random = new Random();

        // Запускаем несколько потоков
        for (int i = 0; i < numberOfThreads; i++)
        {
            Thread t = new Thread(() =>
            {
                while (true)
                {
                    // Нагружаем процессор на заданный процент
                    var sw = Stopwatch.StartNew();
                    while (sw.ElapsedMilliseconds < workTime)
                    {
                        // Сложные вычисления для загрузки процессора
                        // Используем более сложные вычисления для увеличения нагрузки
                        double result = 0;
                        for (int j = 0; j < 1000; j++)
                        {
                            result += Math.Sqrt(random.NextDouble());
                        }
                    }

                    // Отдыхаем, чтобы не создать 100% нагрузку
                    // Используем точный расчет времени отдыха
                    long sleepTime = idleTime - sw.ElapsedMilliseconds;
                    if (sleepTime > 0)
                    {
                        Thread.Sleep((int)sleepTime);
                    }
                }
            });
            t.IsBackground = true; // Потоки будут завершаться при завершении программы
            t.Start();
        }
    }
}
