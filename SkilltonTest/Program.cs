using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SkilltonTest;
using SkilltonTest.Actions;


HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
Dependencies.ConfigureDependencies(builder.Configuration, builder.Services);
using IHost host = builder.Build();

bool exit = false;

while (!exit)
{
    Console.WriteLine("1. Добавление нового сотрудника");
    Console.WriteLine("2. Просмотр всех сотрудников");
    Console.WriteLine("3. Обновление информации о сотруднике");
    Console.WriteLine("4. Удаление сотрудника");
    Console.WriteLine("5. Выход");

    string? action = Console.ReadLine();
    if (action is null)
        continue;

    int actionNumber;
    try
    {
        actionNumber = Convert.ToInt32(action);
    }
    catch
    {
        continue;
    }

    switch (actionNumber)
    {
        case 1:
            host.Services.GetRequiredService<AddNewEmployerAction>().Start();
            break;
        case 2:
            host.Services.GetRequiredService<GetAllEmployersAction>().Start();
            break;
        case 3:
            host.Services.GetRequiredService<EditEmployerAction>().Start();
            break;
        case 4:
            host.Services.GetRequiredService<RemoveEmployerAction>().Start();
            break;
        case 5:
            exit = true;
            break;
    }
}
