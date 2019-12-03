<?php

// create server variables
    $server_name = "localhost";
    $server_username = "root";
    $server_password = "";
    $database_name = "nsirpg";

//user input
    $email = "bob@home"; //$_POST["email"];

//check connection
    $conn = new mysqli($server_name, $server_username, $server_password, $database_name);
    if (!$conn)
    {
        echo "Unable to connect to ".$database_name;
    }
    else
    {
        echo  "Connection to ".$database_name." successful \n";
    }

    //http://localhost:81/nsirpg/CheckEmail.php

//create the query and execute
    $checkEmailQuery = "SELECT username FROM users WHERE email = '".$email."'";
    $checkEmailResult = mysqli_query($conn, $checkEmailQuery);

//check if email exists
    if (mysqli_num_rows($checkEmailResult) > 0)
    {
        while ($row = mysqli_fetch_assoc($checkEmailResult))
        {
            echo $row["username"];
            return;
        }
    }
    else
    {
        echo "email not found";
        return;
    }

//loop through each record in the result object

