using System.Net.NetworkInformation;

//Метод точка входа.
//Тестовый пул
void Starting()
{
    Console.WriteLine("Успешный запуск\nВведите значение в формате ниже\n");
    Console.WriteLine("KingX KingY RookX RookY ElephantX ElephantY\n");
    string coordinats = Console.ReadLine();
    string[] array_coordinats = coordinats.Split(' ');
    coords_making(int.Parse(array_coordinats[0]), int.Parse(array_coordinats[1]), int.Parse(array_coordinats[2]), int.Parse(array_coordinats[3]), int.Parse(array_coordinats[4]), int.Parse(array_coordinats[5]));
}
//Загрузка координат
void coords_making( int KX, int KY, int RX, int RY, int EX, int EY)
{
    Console.WriteLine("Коордианты:\n\n"+ "KingX - " + KX + "\nKingY - " + KY + "\nRookX - " + RX + "\nRookY - " + RY + "\nElephantX - " + EX + "\nElephantY - " + EY + "\n");
    if (checking_borders(KX, KY, RX, RY, EX, EY) == true)
    {
        //Console.WriteLine("Проверка на совпадение координат фигур");
        if (checking_same_coords(KX, KY, RX, RY, EX, EY) == true)
        {
            Console.WriteLine("Совпадение координат фигур. Заверешение работы.");
        }
        else
        {
            Console.WriteLine("\nНачало проверки на угрозы");

            if ((checking_alarm_elephant(KX, KY, RX, RY, EX, EY) & checking_alarm_rook(KX, KY, RX, RY, EX, EY)) == true)
            {
                Console.WriteLine("Угроза от слона и ладьи");
            }
            if ((checking_alarm_elephant(KX, KY, RX, RY, EX, EY) & checking_alarm_rook(KX, KY, RX, RY, EX, EY)) == false)
            {
                if (checking_alarm_elephant(KX, KY, RX, RY, EX, EY) == true)
                {
                    Console.WriteLine("Угроза от слона");
                }
                else
                {
                    Console.WriteLine("");
                }

                if (checking_alarm_rook(KX, KY, RX, RY, EX, EY) == true)
                {
                    Console.WriteLine("Угроза от ладьи");
                }
                else
                {
                    Console.WriteLine("");
                }
            }
            if ((checking_alarm_elephant(KX, KY, RX, RY, EX, EY) | checking_alarm_rook(KX, KY, RX, RY, EX, EY)) == false)
                {
                    Console.WriteLine("Угроз нет");
                }
        }
        Console.WriteLine("\nКонец.");
    }
    else
    {
        Console.WriteLine("Остановка программы, неверные координаты");
    }
}
//Метод проверки координат фигур, в случае превышение ими игровой доски 8x8, сеанс прерывается.
bool checking_borders( int KX, int KY, int RX, int RY, int EX, int EY )
{
   if ((KX < 9 & KX > 0) & ((KY < 9) & (KY > 0)) & (RX < 9 & RX > 0) & ((RY < 9) & (RY > 0)) & (EX < 9 & EX > 0) & ((EY < 9) & (EY > 0)))
    {
        Console.WriteLine("Границы доски не были нарушенны, все фигуры установленны внутри доски");
        return true;
    }
   else
    {
        Console.WriteLine("Границы доски были нарушенны. Неверные координаты.");
        return false;
    }
}
// Метод проверки на взаимное расположение фигур, в случае одинаковых координат сеанс прерывается.
bool checking_same_coords( int KX, int KY, int RX, int RY, int EX, int EY )
{
    if ((KX == RX) & (KY == RY) || (KX == EX) & (KY == EY) || (RX == EX) & (RY == EY))
    {
        Console.WriteLine("Фигуры расположенны на одинаковых координатах");
        return true;
    }
    else { return false; }
}
// Метод проверки, угрозы от слона
bool checking_alarm_elephant( int KX, int KY, int RX, int RY, int EX, int EY )
{
    if (Math.Abs(KX - EX) == Math.Abs(KY - EY))
    {
        return true;
    }
    else 
    {
        return false; 
    }
}
// Метод проверки, угрозы от ладьи
bool checking_alarm_rook( int KX, int KY, int RX, int RY, int EX, int EY)
{
    if ((KX == RX) || (KY == RY))
    {
        return true;
    }
    else
    {
        return false;
    }
}

//Starting();
//coords_making(1, 2, 6, 7, 7, 5);
coords_making(2, 2, 2, 4, 7, 6);



// 2 2 - нехватка чисел
// 10 10 5 5 8 8 - (неверные координаты)
// 4 4 4 4 5 5 - (совпадают координаты фигур)
// 2 2 7 8 4 4 - Угроза от слона
// 2 2 2 4 7 6 - Угроза от ладьи
// 2 2 2 4 4 4 - Угроза обоих 
// 1 2 6 7 7 5 - Угроз отсуствуют