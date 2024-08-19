using Football;
using Football.Interfaces;

int relativeScore = 0;
int cycleCount = 0;

Console.WriteLine("Играем в футбол.\n" +
                  "В одной команде нападающий, а во второй вратарь.\n" +
                  "Ведём относительный счёт.\n" +
                  "Нападающий увеличивает счётчик голов, а вратарь уменьшает (но счёт не может быть меньше 0)\n");

Console.WriteLine("Введите голевую силу нападающего:");
IPlayer forward = new Forward(int.Parse(Console.ReadLine() ?? throw new InvalidOperationException()));
Console.WriteLine("Введите голевую силу вратаря:");
IPlayer goalkeeper = new Goalkeeper(int.Parse(Console.ReadLine() ?? throw new InvalidOperationException()));

ITeam team1 = new Team(forward);
ITeam team2 = new Team(goalkeeper);

Console.WriteLine($"Матч начался. Счёт: {relativeScore}\n");
do
{
    Console.WriteLine("Начат очередной цикл матча");
    cycleCount++;
    team1.Play(ref relativeScore);
    team2.Play(ref relativeScore);
    Console.WriteLine($"Цикл матча завершён. Счёт {relativeScore}.\nДля окончания матча введите любой символ");
} while (string.IsNullOrWhiteSpace(Console.ReadLine()));

Console.WriteLine($"Матч окончен. Всего циклов игры: {cycleCount} Финальный счёт: {relativeScore}");