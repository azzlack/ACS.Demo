function setupProviders(data) {
    $.each(data, function(i, o) {
        var button = "<li style='" + ((o.ImageUrl.length > 0) ? "background-image: url('" + o.ImageUrl + "')" : "") + "'><a href='" + o.LoginUrl + "'>" + o.Name + "</a></li>";
        $(".providers").append(button);
    });
}

$(function () {
    var realm = window.location.protocol + "//" + window.location.host;
    var url = "https://eyecatch.accesscontrol.windows.net/v2/metadata/IdentityProviders.js?protocol=wsfederation&version=1.0&realm=" + encodeURIComponent(realm);
    
    $.ajax({
        url: url,
        type: "GET",
        dataType: "jsonp",
        jsonpCallback: "setupProviders"
    });
});