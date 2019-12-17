using LandingPage.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System;

namespace LandingPage.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel(IOptions<CDNSettings> options)
        {
            MediaEndpoint = options?.Value?.CDNMediaEndpoint;
            VideoEndpoint = options?.Value?.CDNVideoEndpoint;
        }

        [BindProperty]
        public bool SettingsConfigured { get; private set; } = false;

        [BindProperty]
        public string MediaEndpoint { get; private set; }

        [BindProperty]
        public string VideoEndpoint { get; private set; }

        public void OnGet()
        {
            SettingsConfigured = !(String.IsNullOrEmpty(MediaEndpoint) || String.IsNullOrEmpty(VideoEndpoint));
        }
    }
}