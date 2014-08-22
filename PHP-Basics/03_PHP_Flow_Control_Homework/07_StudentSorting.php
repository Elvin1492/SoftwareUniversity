<!DOCTYPE html>
<html>
	<head>
		<title>Student Sorting</title>
		<meta charset = 'UTF-8' />
		<link rel="stylesheet" href="styles/studentSorting.css">
		<script type="text/javascript" src="scripts/studentSorting.js" ></script>
	</head>
	<body>
		<form  action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]);?>" method="post" id="studentForm">
			<table class="table">
				<thead>
					<tr>
						<th>First Name:</th>
						<th>Last Name:</th>
						<th>Email:</th>
						<th> Exam score:</th>
					</tr>
				</thead>
				<tbody id="students">
                <!-- HERE WE ADD NEW STUDENTS BY CALLING THE JS FUNCTION addStudents()-->		
				</tbody>
				<script>addStudent();</script>
			</table><br/>
			<input type="button" name="add" value="Add" onclick="addStudent()"/>
			Sort by: <select name="sortBy">
				<option value="default" selected disabled>Sort by</option>
				<option value="firstName">First name</option>
				<option value="firstName">last name</option>
				<option value="firstName">Email</option>
				<option value="firstName">Score</option>
			</select>
			Order: <select name="order">
				<option value="default" selected disabled>Order</option>
				<option value="firstName">Descending</option>
				<option value="firstName">Ascending</option>
			</select>
			<input type="submit" name="submit" value="SUBMIT" />
		</form><br/>
		<!--PHP SCRIPT FOR PRINTING THE SORTED TABLE-->
		<?php
		class Student {
			var $first_name;
			var $last_name;
			var $email;
			var $score;
			function __construct ($fname,$lname,$email,$score) {
	        $this->first_name = $fname;
			$this->last_name = $lname;
			$this->email = $email;
			$this->score = $score;
	    	}
		}
		
		$student = new Student("borislav",'hristov','borio@abv.bg', 400);
		var_dump($student);
		 
		?>
	</body>
</html>