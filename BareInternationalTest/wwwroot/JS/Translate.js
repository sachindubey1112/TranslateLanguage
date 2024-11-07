function searchTranslate() {
    var requestText1 = $("#requestText").val().trim();
    if (requestText1 == "") {
        alert("please type in search box");
        return;
    }
    var data = {
        requestText: requestText1 // or any other form data
    };
    fetch('api/v1/Converter', {
        method: 'POST', // HTTP method
        headers: {
            'Content-Type': 'application/json' // Set the content type as JSON
        },
        body: JSON.stringify(data) // Send the data as a JSON string
    })
        .then(response => response.json())  // Parse the JSON response
        .then(data => {
            console.log('Success:', data);
            // Handle the response data
        })
        .catch(error => {
            console.error('Error:', error);
            // Handle errors
        });
    alert("hello " + requestText);
}