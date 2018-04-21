function attachEvents() {
    $('#submit').click(GetWeather);

    function GetWeather() {
        $('#forecast #current').empty();
        $('#forecast #current #upcoming').empty();
        let location = $('#location').val();
        GetCurrentCondition(location);
        GetThreeDayForecast(location);
    }


    function GetCurrentCondition(location) {
        let locationCode = location.toLowerCase() === 'new york' ? 'ny' : location.toLowerCase();

        $.get({
            method: 'GET',
            url: `https://judgetests.firebaseio.com/forecast/today/${locationCode}.json `,
            success: DisplayCurrentCondition
        })

        function DisplayCurrentCondition(data) {
            $('#forecast').show();
            $('#forecast #current')
                .append(`<span class="condition symbol">${GetSymbol(data.forecast.condition)}</span>`)
                .append($(`<span class="condition">`)
                    .append(`<span class="forecast-data">${data.name}</span>`)
                    .append(`<span class="forecast-data">${data.forecast.low}°/${data.forecast.high}°</span>`)
                    .append(`<span class="forecast-data">${data.forecast.condition}</span>`));

        }
    }

    function GetThreeDayForecast(location) {
        let locationCode = location.toLowerCase() === 'new york' ? 'ny' : location.toLowerCase();

        $.get({
            method: 'GET',
            url: `https://judgetests.firebaseio.com/forecast/upcoming/${locationCode}.json`,
            success: DisplayThreeDayForecast
        })

        function DisplayThreeDayForecast(data) {
            for (let day of data.forecast) {
                $('#forecast #upcoming')
                    .append(`<span class="condition symbol">${GetSymbol(day.condition)}</span>`)
                    .append(`<span class="condition">`)
                    .append(`<span class="forecast-data">${day.low}°/${day.high}°</span>`)
                    .append(`<span class="forecast-data">${day.condition}</span>`);
            }
        }
    }

    function GetSymbol(condition) {
        switch (condition) {
            case 'Sunny': return `☀`;
            case 'Partly sunny': return `⛅`;
            case 'Overcast': return `☁`;
            case 'Rain': return `☂`;
        }
    }
}   