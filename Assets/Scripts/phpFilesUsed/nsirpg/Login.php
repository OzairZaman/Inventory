<?php
    session_start();
    ob_start();
// Create server variable
    $server_name = "localhost";
    $server_username = "root";
    $server_password = "";
    $database_name = "nsirpg";

//user input variables
    $username = $_POST["username"]; //"bob2"; //
    $password = $_POST["password"]; //"xx"; //


    $_SESSION['user'] = $username;
    echo  $_SESSION['user']." - from login";

    //echo $username."  -  ".$password;

//check connection
    $conn = new mysqli($server_name, $server_username, $server_password, $database_name);
    if (!$conn)
    {
        echo "failed to connect to ".$server_name." :".mysqli_connect_error();
    }
    else
    {
        //echo "Connection success - " .$database_name." \n";
    }

    //http://localhost:81/nsirpg/Login.php

//make select SQL and execute
    $selectUserQuery = "SELECT * FROM users WHERE username = '".$username."'";
    $selectUserResult = mysqli_query($conn, $selectUserQuery);

//check if user exists
    if (mysqli_num_rows($selectUserResult) != 1)
    {
        echo "User ".$server_username." does not exists";
        exit();
    }

//extract salt and hash from query result from above
    $existingInfo = mysqli_fetch_assoc($selectUserResult);
    $hash = $existingInfo["hash"];
    $salt = $existingInfo["salt"];


//encrypt user entered password (turn it into hash)
    $newHash = crypt($password, $salt);

//compare existing hash vs userInput hash
    if ($hash != $newHash)
    {
        echo "Password is incorrect";
        exit();
    }
//if same do action
    ob_end_clean();
    echo  json_encode("c");
