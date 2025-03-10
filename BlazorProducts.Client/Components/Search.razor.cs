﻿using Microsoft.AspNetCore.Components;

namespace BlazorProducts.Client.Components
{
    public partial class Search
    {
        public string SearchTerm { get; set; }

        private Timer _timer;
        [Parameter]
        public EventCallback<string> onSearchChanged { get; set; }

        private void SearchChanged()
        {
            if (_timer != null)
                _timer.Dispose();
            _timer = new Timer(OnTimerElapsed, null, 500, 0);
        }

        private void OnTimerElapsed(object sennder)
        {
            onSearchChanged.InvokeAsync(SearchTerm);
            _timer.Dispose();
        }
    }
}
