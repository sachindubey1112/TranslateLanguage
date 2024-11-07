function searchTranslate() {
    var requestText1 = $("#requestText").val().trim();
    if (requestText1 == "") {
        alert("please type in search box");
        return;
    }
    var data = {
        requestText: requestText1 // or any other form data
    };
    $("#searchbtn").addClass("disabled");
    fetch('api/v1/Converter', {
        method: 'POST', // HTTP method
        headers: {
            'Content-Type': 'application/json' // Set the content type as JSON
        },
        body: JSON.stringify(data) // Send the data as a JSON string
    })
        .then(response => response.json())  // Parse the JSON response
        .then(data => {
            if (data.translateModel.status == "success" && data.translateModel.errorMsg == "" && data.translate != null) {
                console.log('Success:', data);
            }
            else if (data.translateModel.status == "error" && data.translateModel.errorMsg != "") {
                alert(data.translateModel.errorMsg);
            }
            $("#searchbtn").removeClass("disabled");
            // Handle the response data
        })
        .catch(error => {
            console.error('Error:', error);
            $("#searchbtn").removeClass("disabled");
            // Handle errors
        });
    //alert("hello " + requestText);
}