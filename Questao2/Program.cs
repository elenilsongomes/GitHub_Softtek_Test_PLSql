using Questao2;
using Newtonsoft.Json;
using System.Net.Http.Headers;

public class Program
{
    public static void Main()
    {
        string teamName;
        int year;
        int pages;
        int totalGoals;

        teamName = "Paris Saint-Germain";
        year = 2013;
        pages = 3;
        totalGoals = GetTotalScoredGoals(teamName, year, pages);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        teamName = "Chelsea";
        year = 2014;
        pages = 3;
        totalGoals = GetTotalScoredGoals(teamName, year, pages);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static int GetTotalScoredGoals(string teamName, int year, int pages)
    {
        CallWebAPIAsync(teamName, year, pages).Wait();

        return Global.totalGoals;
    }

    static async Task CallWebAPIAsync(string teamName, int year, int pages)
    {
        var teams = new List<string>() { "team1", "team2" };
        var numberPages = Enumerable.Range(1, pages).ToList();

        Global.resultWebAPIData.Clear();

        foreach (var team in teams)
        {
            foreach (var page in numberPages)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://jsonmock.hackerrank.com/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string parameterGet = $"api/football_matches?year={year}&{team}={teamName}&page={page}";

                    HttpResponseMessage response = await client.GetAsync(parameterGet);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();

                        ResultWebAPI resultWebAPI = JsonConvert.DeserializeObject<ResultWebAPI>(json);

                        foreach (var dataElement in resultWebAPI.Data)
                        {
                            Global.resultWebAPIData.Add(dataElement);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Internal server Error");
                    }
                }
            }
        }

        int totalGoalsTeam1 = Global.resultWebAPIData
            .Where(item => item.Year == year && item.Team1 == teamName)
            .Sum(item => item.Team1goals);

        int totalGoalsTeam2 = Global.resultWebAPIData
            .Where(item => item.Year == year && item.Team2 == teamName)
            .Sum(item => item.Team2goals);

        Global.totalGoals = 0;
        Global.totalGoals = totalGoalsTeam1 + totalGoalsTeam2;
    }
}
