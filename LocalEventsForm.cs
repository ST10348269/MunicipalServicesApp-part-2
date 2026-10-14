using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class LocalEventsForm : Form
    {
        // Advanced Data Structures
        SortedDictionary<DateTime, List<EventItem>> eventsByDate = new SortedDictionary<DateTime, List<EventItem>>();
        Dictionary<string, List<EventItem>> eventsByCategory = new Dictionary<string, List<EventItem>>();
        HashSet<string> uniqueCategories = new HashSet<string>();
        Queue<string> recentSearches = new Queue<string>();

        public LocalEventsForm()
        {
            InitializeComponent();
            SeedSampleEvents();
            LoadCategories();
            DisplayAllEvents();
        }

        private void SeedSampleEvents()
        {
            AddEvent(new EventItem("Community Clean-up Day", "Community", new DateTime(2026, 10, 20), "Join us to clean the local park"));
            AddEvent(new EventItem("Water Saving Workshop", "Utilities", new DateTime(2026, 10, 22), "Learn how to save water at home"));
            AddEvent(new EventItem("Road Maintenance Notice", "Roads", new DateTime(2026, 10, 18), "Main Road will be closed for repairs"));
            AddEvent(new EventItem("Youth Sports Tournament", "Sports", new DateTime(2026, 10, 25), "Local youth soccer competition"));
            AddEvent(new EventItem("Load Shedding Schedule Update", "Utilities", new DateTime(2026, 10, 15), "Updated stages for the week"));
            AddEvent(new EventItem("Recycling Awareness Day", "Community", new DateTime(2026, 10, 28), "Bring your recyclables to the community hall"));
            AddEvent(new EventItem("Farmers Market", "Community", new DateTime(2026, 11, 2), "Fresh produce from local farmers"));
            AddEvent(new EventItem("Fire Safety Demonstration", "Safety", new DateTime(2026, 10, 30), "Free fire safety tips for residents"));
        }

        private void AddEvent(EventItem ev)
        {
            if (!eventsByDate.ContainsKey(ev.Date))
                eventsByDate[ev.Date] = new List<EventItem>();
            eventsByDate[ev.Date].Add(ev);

            if (!eventsByCategory.ContainsKey(ev.Category))
                eventsByCategory[ev.Category] = new List<EventItem>();
            eventsByCategory[ev.Category].Add(ev);

            uniqueCategories.Add(ev.Category);
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("All Categories");
            foreach (string cat in uniqueCategories)
            {
                cmbCategory.Items.Add(cat);
            }
            cmbCategory.SelectedIndex = 0;
        }

        private void DisplayAllEvents()
        {
            lstEvents.Items.Clear();
            foreach (var dateGroup in eventsByDate)
            {
                foreach (var ev in dateGroup.Value)
                {
                    lstEvents.Items.Add(ev);
                }
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            DisplayAllEvents();
            lstRecommendations.Items.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string selectedCategory = cmbCategory.SelectedItem?.ToString();
            DateTime selectedDate = dtpDate.Value.Date;

            lstEvents.Items.Clear();

            if (!string.IsNullOrEmpty(selectedCategory) && selectedCategory != "All Categories")
            {
                recentSearches.Enqueue(selectedCategory);
                if (recentSearches.Count > 5)
                    recentSearches.Dequeue();
            }

            foreach (var dateGroup in eventsByDate)
            {
                foreach (var ev in dateGroup.Value)
                {
                    bool categoryMatch = selectedCategory == "All Categories" || ev.Category == selectedCategory;
                    bool dateMatch = ev.Date.Date >= selectedDate;

                    if (categoryMatch && dateMatch)
                    {
                        lstEvents.Items.Add(ev);
                    }
                }
            }

            ShowRecommendations();
        }

        private void ShowRecommendations()
        {
            lstRecommendations.Items.Clear();

            if (recentSearches.Count == 0)
            {
                lstRecommendations.Items.Add("Search for events to get recommendations");
                return;
            }

            string lastSearch = recentSearches.Last();

            if (eventsByCategory.ContainsKey(lastSearch))
            {
                foreach (var ev in eventsByCategory[lastSearch].Take(3))
                {
                    lstRecommendations.Items.Add(ev);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenuForm mainMenu = new MainMenuForm();
            mainMenu.Show();
            this.Hide();
        }
    }
}