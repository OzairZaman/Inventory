<?php

// server variables
    $server_name = "localhost";
    $server_username = "root";
    $server_password = "";
    $database_name = "nsirpg";

// user variable
    $username = "bob2"; //$_POST["username"];
    $password = "xx"; //$_POST["password"};

    // create connection
    $conn = new mysqli($server_name, $server_username, $server_password, $database_name);
    if (!$conn)
    {
        echo nl2br("connection failed".mysqli_connect_error()." \n") ;
    }
    else
    {
        echo nl2br("connection successfull \n");
    }
    //http://localhost:81/nsirpg/UpdatePassword.php

    // hash up new password
    $salt = "\$5\$round=5000\$"."supercalifragilisticexpialidocious".$username."\$";
    $hash = crypt($password, $salt);

    echo nl2br($username." \n") ;
    // create update query and execute
    $updatePasswordQuery = "UPDATE users SET salt = '".$salt."', hash = '".$hash."' WHERE username = '".$username."'";

    echo nl2br($updatePasswordQuery." \n") ;

    $updatePasswordResult = mysqli_query($conn, $updatePasswordQuery);
    if ($updatePasswordResult)
    {
        echo nl2br("password updated successfully \n") ;
    }
    else
    {
        echo nl2br("something fucked up");
    }
