<?php
//Server Variables. Allows us to log into the server
    $server_name = "localhost";
    $server_username = "root";
    $server_password = "";
    $server_database = "nsirpg";

//User variables
    $username = "bob2"; //$_POST["username"];
    $email = "bob@home"; //$_POST["email"];
    $password = "pass"; //$_POST["password"];

//Connect to the database and check connection
    $conn = new mysqli($server_name, $server_username, $server_password, $server_database);
    if (!$conn)
    {
        die("Connection failed.".mysqli_connect_error());
    }
    else
    {
        echo "Connection success - " .$server_database."\n";
    }
    //http://localhost:81/nsirpg/InsertUser.php

//Check if user already exists
    $nameCheckQuery = "SELECT username FROM users WHERE username ='".$username."'";
    $nameCheck = mysqli_query($conn, $nameCheckQuery);
    if (mysqli_num_rows($nameCheck) > 0)
    {
        echo "user already exists";
        exit(); // this should exit the script
    }

// Does the email already exist?
    $emailcheckquery = "SELECT email FROM users WHERE email = '".$email."'";
    $emailCheck = mysqli_query($conn,$emailcheckquery);
    if(mysqli_num_rows($emailCheck)>0)
    {
        echo "Email Already Exists";
        exit();
    }

//create new user
    $salt = "\$5\$round=5000\$"."supercalifragilisticexpialidocious".$username."\$";
    $hash = crypt($password,$salt);
    $insertUserQuery = "INSERT INTO users (username, email, salt, hash) VALUES ('".$username."','".$email."','".$salt."','".$hash."');";
    mysqli_query($conn, $insertUserQuery) or die("Failed to insert usr -  ".$username);
    echo "Successfully created user -".$username;



