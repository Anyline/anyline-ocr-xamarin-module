using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Anyline
{
    /// <summary>
    /// This page is rendered natively in each individual platform.
    /// The scanning results are received in the 'ShowResultsAction' action.
    /// </summary>
    public class ScanPage : ContentPage
    {
        public string ConfigurationFile = "";
        public Action<Object> ShowResultsAction;

        public ScanPage(string configurationFile)
        {
            BackgroundColor = Color.Black;
            Title = "Anyline Xamarin Module";
            ConfigurationFile = configurationFile;

            ShowResultsAction += (r) =>
            {
                var results = r as Dictionary<string, object>;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    Navigation.InsertPageBefore(new ResultsPage(results, configurationFile), this);
                    await Navigation.PopAsync();
                });
            };
        }
    }
}