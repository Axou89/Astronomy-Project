using System.Text.RegularExpressions;

namespace asenecal_nasa
{
    public partial class Form1 : Form
    {

        private static string apodURL = "https://api.nasa.gov/planetary/apod?api_key=xOCqns7K6jddvGMOxpDtN8ufHoH7BhJ13cZaOZM4";
        private static string apiKey = "xOCqns7K6jddvGMOxpDtN8ufHoH7BhJ13cZaOZM4";
        private string apodExplanation;
        private Dictionary<string, string> astList;
        public Form1()
        {
            InitializeComponent();
            setBackgroundImage();
            setAsteroids();
        }

        // Setter of apodExplanation
        private void setAPODExplanation(string explanation)
        {
            this.apodExplanation = explanation;
        }

        // Getter of apodExplanation
        private string getAPODExplanation()
        {
            return apodExplanation;
        }

        // Setter of astList
        private void setAstList(Dictionary<string, string> dict)
        {
            this.astList = dict;
        }

        // Getter of astList
        private Dictionary<string, string> getAstList()
        {
            return astList;
        }

        // Set the Astronomy Picture of the Day as background image and set the explanation of it
        private async void setBackgroundImage()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(apodURL);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                string[] splitted = content.Split("url");
                string url = splitted[2];
                url = url.Substring(3, url.Length - 6);

                string tempo = splitted[0];
                string[] splittedTempo = tempo.Split("explanation");
                tempo = splittedTempo[1];
                splittedTempo = tempo.Split("   ");
                tempo = splittedTempo[0];
                string explanation = tempo.Substring(3);
                explanation = explanation.Remove(explanation.Length - 5);
                setAPODExplanation(explanation);

                HttpResponseMessage resp = await httpClient.GetAsync(url);
                if (resp.IsSuccessStatusCode)
                {
                    byte[] imageData = await resp.Content.ReadAsByteArrayAsync();

                    using (var stream = new MemoryStream(imageData))
                    {
                        var image = Image.FromStream(stream);

                        this.BackgroundImage = new Bitmap(image);
                        this.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                }
            }
        }

        // Get all asteroids near the earth on a certain date
        private async void setAsteroids()
        {
            string startDate = "2023-01-01";
            string endDate = "2023-01-01";
            string url = "https://api.nasa.gov/neo/rest/v1/feed?start_date=" + startDate + "&end_date=" + endDate + "&api_key=" + apiKey;
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                string[] contents = content.Split("links");

                int index = 0;
                List<string> asteroids = new List<string>();
                foreach (string line in contents)
                {
                    if (index <= 1)
                    {
                        index++;
                        continue;
                    }
                    asteroids.Add(line);
                }
                string[] str_array = asteroids.ToArray();
                Dictionary<string, string> dict = new Dictionary<string, string>();
                string pattern_name = "\"name\":\"(.*?)\",";
                string pattern_id = "\"id\":\"(.*?)\",";
                string pattern_lunar = "\"lunar\":\"(.*?)\",";
                foreach (string str in str_array)
                {
                    Match match_name = Regex.Match(str, pattern_name);
                    Match match_id = Regex.Match(str, pattern_id);
                    Match match_lunar = Regex.Match(str, pattern_lunar);
                    if (match_name.Success)
                    {
                        if (match_lunar.Success)
                        {
                            ListViewItem viewitem = new ListViewItem();
                            viewitem.Text = match_name.Groups[1].Value;
                            viewitem.SubItems.Add(match_lunar.Groups[1].Value);
                            asteroidsList.Items.Add(viewitem);
                        }
                        if (match_id.Success)
                        {
                            
                            dict.Add(match_name.Groups[1].Value, match_id.Groups[1].Value);
                        }
                    }
                }
                setAstList(dict);
            }
        }

        // Write informations about the selected asteroid
        private async void writeAsteroidDetails(string id)
        {
            asteroidDetails.Items.Clear();
            string url = "https://api.nasa.gov/neo/rest/v1/neo/" + id + "?api_key=" + apiKey;
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                string patternDate = "\"close_approach_date\":\"(.*?)\",";
                string patternSpeed = "\"kilometers_per_second\":\"(.*?)\"";
                string patternDistance = "\"lunar\":\"(.*?)\"";

                MatchCollection dateMatch = Regex.Matches(content, patternDate);
                MatchCollection velocityMatch = Regex.Matches(content, patternSpeed);
                MatchCollection distanceMatch = Regex.Matches(content, patternDistance);

                for (int i = 0; i < dateMatch.Count(); i++)
                {
                    string date = dateMatch[i].Groups[1].Value;
                    string velocity = velocityMatch[i].Groups[1].Value;
                    string distance = distanceMatch[i].Groups[1].Value;

                    ListViewItem viewitem = new ListViewItem();
                    viewitem.Text = date;
                    viewitem.SubItems.Add(distance);
                    viewitem.SubItems.Add(velocity);
                    asteroidDetails.Items.Add(viewitem);
                }
            }
        }

        // Select an asteroid from the asteroid list
        private void asteroidsListSelected(object sender, EventArgs e)
        {
            if (asteroidsList.SelectedItems.Count > 0)
            {
                ListViewItem selectedAsteroid = asteroidsList.SelectedItems[0];
                string name = selectedAsteroid.Text;
                string id;
                if (astList.TryGetValue(name, out id))
                {
                    writeAsteroidDetails(id);
                }
            }
        }

        // Event to make appear or disappear the APOD Explanation
        private void apodInfosClick(object sender, EventArgs e)
        {
            apodTxt.Visible = !apodTxt.Visible;
            apodTxtChanged(sender, EventArgs.Empty);
        }

        // Set the apod's explanation for the TextBox
        private void apodTxtChanged(object sender, EventArgs e)
        {
            apodTxt.Text = getAPODExplanation();
        }

        // Event to make appear or disappear the asteroids list and the asteroid details
        private void nearAsteroidsClick(object sender, EventArgs e)
        {
            asteroidsList.Visible = !asteroidsList.Visible;
            asteroidDetails.Visible = !asteroidDetails.Visible;
        }
    }
}