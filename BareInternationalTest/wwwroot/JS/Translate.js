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
            if (data.translateModel.status == "success" && data.translateModel.errorMsg == "" && data.translate != null && data.translateModel.statusCode == 200) {
                console.log('Success:', data);
                swal({
                    title: "Hungarian Translation",
                    text: `The Hungarian translation for '${data.translate.requestText}' is '${data.translate.responseText}'`,
                    confirmButtonText: 'OK'
                });

            }
            else if (data.translateModel.status == "error" && data.translateModel.errorMsg != "" && data.translateModel.statusCode == 2) {
                //alert(data.translateModel.errorMsg);
                //sweetAlert("Oops...", data.translateModel.errorMsg, "error");
                swal({
                    title: "No Translation Found",
                    text: `We're sorry, but no Hungarian translation was found for '${requestText1}'. Please try a different term.`,
                    confirmButtonText: 'OK'
                });
            }
            else if (data.translateModel.status == "error" && data.translateModel.errorMsg != "" && data.translateModel.statusCode == 3) {
                swal({
                    title: "No Status Fetch",
                    text: `${data.translate.errorMsg}'`,
                    confirmButtonText: 'OK'
                });
            }
            else if (data.translateModel.status == "error" && data.translateModel.errorMsg != "" && data.translateModel.statusCode == 500) {
                sweetAlert("Oops...", "Something went wrong!" + data.translateModel.errorMsg, "error");
            }
            else {
                sweetAlert("Oops...", "please try again later","error");
            }
            $("#searchbtn").removeClass("disabled");
            // Handle the response data
        })
        .catch(error => {
            //console.error('Error:', error);
            sweetAlert("Oops...", error, "error");
            $("#searchbtn").removeClass("disabled");
            // Handle errors
        });
    //alert("hello " + requestText);
}