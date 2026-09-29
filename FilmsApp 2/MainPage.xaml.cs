using FilmsApp.Models;
using FilmsApp.Services;

namespace FilmsApp;

public partial class MainPage : ContentPage
{
    private readonly TmdbService _tmdbService;

    public MainPage()
    {
        InitializeComponent();

        _tmdbService = new TmdbService("e51d0e070f66de2c72ee396e547b0f5d");
    }

    private async void OnSearchClicked(object sender, EventArgs e)
    {
        string query = SearchEntry.Text ?? "";

        if (string.IsNullOrWhiteSpace(query))
            return;

        try
        {
            LoadingIndicator.IsVisible = true;
            LoadingIndicator.IsRunning = true;

            List<Movie> movies =
                await _tmdbService.SearchMoviesAsync(query);

            MoviesList.ItemsSource = movies;
        }
        catch (Exception ex)
        {
            await DisplayAlert(
                "Error",
                $"Failed to search for movies.\n\n{ex.Message}",
                "OK");
        }
        finally
        {
            LoadingIndicator.IsRunning = false;
            LoadingIndicator.IsVisible = false;
        }
    }
}