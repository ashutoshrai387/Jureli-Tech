function addStudent() {
    var data = {
        "class": "Computer Science",
        "subject": ["English", "Math", "Programming"]
    };

    var xhr = new XMLHttpRequest();
    xhr.open("POST", "https://myjureli.site/student/add", true);
    xhr.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    xhr.onreadystatechange = function () {
        if (xhr.readyState === XMLHttpRequest.DONE) {
            if (xhr.status === 200) {
                var response = JSON.parse(xhr.responseText);
                if (response.status === "success") {
                    console.log("Student added successfully");
                } else {
                    console.log("Failed to add student: " + response.message);
                }
            } else {
                console.error("Error occurred while adding student");
            }
        }
    };
    xhr.send(JSON.stringify(data));
}

// Invoke the function to add student
addStudent();