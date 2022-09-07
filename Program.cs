/*
Задача 41: Пользователь вводит с клавиатуры M чисел. Посчитайте, сколько чисел больше 0 ввёл пользователь.
0, 7, 8, -2, -2 -> 2
1, -7, 567, 89, 223-> 3
*/
int MoreThenNull()
{
    Console.Write("Введите целое число: ");
    string numb = Console.ReadLine();
    int count = 0;
    while (numb != "q")
    {
        int number = Convert.ToInt32(numb);
        if (number>0) count++;
        Console.Write("Введите целое число (для выхода введите 'q'): ");
        numb = Console.ReadLine();
    }
    return count;
}
Console.WriteLine($"Количество чисел, которые вы ввели больше нуля = {MoreThenNull()}");
/*
Задача 43: Напишите программу, которая найдёт точку пересечения двух прямых, заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.
b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)
*/
double[] GetCrossPoint()
{
    Console.Write("Для поиска точки пересечения двух прямых заданных формулами  y = k * x + b, необходимо ввести данные.\nВведите для первой прямой k1 = ");
    double k1 = Convert.ToDouble(Console.ReadLine());
    Console.Write("Введите для первой прямой b1 = ");
    double b1 = Convert.ToDouble(Console.ReadLine());
    Console.Write("Введите для второй прямой k2 = ");
    double k2 = Convert.ToDouble(Console.ReadLine());
    Console.Write("Введите для второй прямой b2 = ");
    double b2 = Convert.ToDouble(Console.ReadLine());
    double[] point = new double[3];
    try
    {
        point[0] = (b2-b1)/(k1-k2);
        point[1] = k1 * point[0] + b1;
        point[2] = k2 * point[0] + b2;
        if (point[1] == point[2]) Console.WriteLine($"Точками пересечения являются X = {point[0]} y = {point[1]}");
        else Console.WriteLine("У данных прямых нет точек пересечения");
    }
    catch (System.Exception)
    {
        Console.WriteLine("У данных прямых нет точек пересечения");
    }
    return point;
}
double[] crosspoint = GetCrossPoint();
/*
задача 40 - HARD необязательная. На вход программы подаются три целых положительных числа. Определить , является ли это сторонами треугольника. 
Если да, то вывести всю информацию по нему - площадь, периметр, значения углов треугольника в градусах, является ли он прямоугольным, равнобедренным, равносторонним.
*/
string ChekTriangle()
{
    Console.Write("Введите длину первой строны треугольника: ");
    double first = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите длину второй строны треугольника: ");
    double second = Convert.ToInt32(Console.ReadLine());
    Console.Write("Введите длину третей строны треугольника: ");
    double third = Convert.ToInt32(Console.ReadLine());
    if (first < second+third && second < first+third && third < first+second)
    {
        Console.WriteLine($"Треугольник со сторонами {first} {second} {third} существует");
        double perimeter = first + second + third; 
        double halfPerim = perimeter/2;
        double square = Math.Round(Math.Sqrt(halfPerim*(halfPerim-first)*(halfPerim-second)*(halfPerim-third)),2);
        double btwFS = Math.Acos((Math.Pow(first,2)+Math.Pow(second,2)-Math.Pow(third,2))/(2*first*second));
        double btwFT = Math.Acos((Math.Pow(first,2)+Math.Pow(third,2)-Math.Pow(second,2))/(2*first*third));
        double btwST = Math.Acos((Math.Pow(second,2)+Math.Pow(third,2)-Math.Pow(first,2))/(2*second*third));
        if (btwFS == 90 || btwFT == 90 || btwST== 90) Console.WriteLine("Треугольник прямоугольный");
        if (btwFS == btwFT || btwFS == btwST || btwFT == btwST) Console.WriteLine("Треугольник равнобедренный");
        if (first==second && first==third && third == second) Console.WriteLine("Треугольник равносторонний");
        return $"перемитр = {perimeter}\nплощадь = {square}\nуглы = {btwFS}, {btwFT}, {btwST}";
    }
    else return $"Треугольник со сторонами {first} {second} {third} НЕ существует";
}

Console.WriteLine(ChekTriangle());
/*
задача 2 HARD необязательная. Сгенерировать массив случайных целых чисел размерностью m*n (размерность вводим с клавиатуры).
 Вывести на экран красивенько таблицей. Перемешать случайным образом элементы массива, причем чтобы каждый гарантированно переместился 
 на другое место (возможно для этого удобно будет использование множества) и выполнить это за m*n / 2 итераций. То есть если массив три
  на четыре, то надо выполнить не более 6 итераций. И далее в конце опять вывести на экран как таблицу.
  */