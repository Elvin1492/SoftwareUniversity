var ajaxRequester = (function() {
    var PARSE_APP_ID = "onbdyBF9UWOEKT27dIrX5c2F0RgSCIxVx5qU8Kwb";
    var PARSE_REST_API_KEY = "7dGtw9A71CTPEnw8l4MuDrTih47sglobMOMac5JU";

    var requestHeaders = {
        "X-Parse-Application-Id": PARSE_APP_ID,
        "X-Parse-REST-API-Key": PARSE_REST_API_KEY
    };

    var baseUrl = "https://api.parse.com/1/";

    var makeRequest = function(method, url, data, success, error) {
        $.ajax({
            type: method,
            headers: requestHeaders,
            url: url,
            contentType: 'application/json',
            data: JSON.stringify(data) || undefined,
            success: success,
            error: error
        });
    };

    // request with session token
    var sessionRequest = function(sessionToken, method, url, data,  success, error) {
        var headersWithToken = getHeadersWithSessionToken(sessionToken);
        $.ajax({
            type: method,
            headers: headersWithToken,
            url: url,
            contentType: 'application/json',
            data: JSON.stringify(data) || undefined,
            success: success,
            error: error
        });
    };

    var makeGetRequest = function(url, success, error) {
        return makeRequest('GET', url, null, success, error);
    };

    var makePostRequest = function(url, data, success, error) {
        return makeRequest('POST', url, data, success, error);
    };

    var makePutRequest = function(url, data, success, error) {
        return makeRequest('PUT', url, data, success, error);
    };

    var makeDeleteRequest = function(url, success, error) {
        return makeRequest('DELETE', url, null, success, error);
    };

    // requests with session token
    var makeSessionGetRequest = function(sessionToken, url, success, error) {
        return sessionRequest(sessionToken,'GET', url, null, success, error);
    };

    var makeSessionPostRequest = function(sessionToken, url, data, success, error) {
        return sessionRequest(sessionToken, 'POST', url, data, success, error);
    };

    var makeSessionPutRequest = function(sessionToken, url, data, success, error) {
        return sessionRequest(sessionToken, 'PUT', url, data, success, error);
    };

    var makeSessionDeleteRequest = function(sessionToken, url, success, error) {
        return sessionRequest(sessionToken, 'DELETE', url, null, success, error);
    };    
    
    // add sesson token to headers 
    function getHeadersWithSessionToken(sessionToken) {
        var headersWithToken = JSON.parse(JSON.stringify(requestHeaders));
        headersWithToken['X-Parse-Session-Token'] = sessionToken;
        return headersWithToken;
    }

    return {
        get: makeGetRequest,
        post: makePostRequest,
        put: makePutRequest,
        delete: makeDeleteRequest,
        getSession: makeSessionGetRequest,
        postSession: makeSessionPostRequest,
        putSession: makeSessionPutRequest,
        deleteSession: makeSessionDeleteRequest,
    };
}());