<!DOCTYPE html>
<html>
	<head>
		<title>CV Generator</title>
		<meta charset='UTF-8' />
		<!-- this is the styling of the genrated CV -->
		<style>
			div#CV {
				position:relative;
				top: -670px;
				left: 600px;
				border:4px dashed black;
				width: 600px;
				height: auto;
				padding:15px;
			}
			h1 {
				text-align: center;
			}
			table.info {
				border: 1px solid black;
				margin-left: 30px;
			}
			
			th, td, tr {
				border: 1px solid black;
			}
		</style>
		<!-- JS functions for the add/remove buttons -->
		<script>
		var nextID = 0;		
		function addProgrlang(){
			nextID ++;
			var inputDIV = document.createElement("div");
			inputDIV.setAttribute("id","num" + nextID);
			inputDIV.innerHTML =
			"<input type=\"text\" name=\"program-langs[]\" />" +
			"<select name=\"level\">" +
				"<option value=\"begginer\">Begginer</option>" +
				"<option value=\"intermediate\">Intermediate</option>" +
				"<option value=\advanced\">Advanced</option>" +
			"</select>";
			document.getElementById("progr-lang").appendChild(inputDIV);
		}
		
		function removeProgrLang(){
			var removeDIV = document.getElementById("progr-lang").lastChild;
			document.getElementById("progr-lang").removeChild(removeDIV);
		}
		
		var nextID2 = 0;
		function addLang(){
			nextID2 ++;
			var inputDIV2 = document.createElement("div");
			inputDIV2.setAttribute("id","num" + nextID2);
			inputDIV2.innerHTML =
				"<input type=\"text\" name=\"langs[]\" />" +
					"<select name=\"comprehension\">" +
						"<option value=\"default\" disabled selected>-Comprehension-</option>"+
						"<option value=\"begginer\">Begginer</option>" +
						"<option value=\"intermediate\">Intermediate</option>" +
						"<option value=\"advanced\">Advanced</option>" +
					"</select>" +
					"<select name=\"reading\">" +
						"<option value=\"default\" disabled selected>-Reading-</option>" +
						"<option value=\"begginer\">Begginer</option>" +
						"<option value=\"intermediate\">Intermediate</option>" +
						"<option value=\"advanced\">Advanced</option>" +
					"</select>" +
					"<select name=\"writing\">" +
						"<option value=\"default\" disabled selected>-Writing-</option>" +
						"<option value=\"begginer\">Begginer</option>" +
						"<option value=\"intermediate\">Intermediate</option>" +
						"<option value=\"advanced\">Advanced</option>" +
					"</select>";
			document.getElementById("langs").appendChild(inputDIV2);
		}
		
		function removeLang(){
			var removeDIV2 = document.getElementById("langs").lastChild;
			document.getElementById("langs").removeChild(removeDIV2);
		}
					
		</script>
	</head>
	
	<body>
		<!-- HTML FORM -->
		<form method="post" action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]);?>">
			<fieldset style="width: 520px;">
				<legend>Personal Information</legend>
				<input type="text" name="first-name" placeholder="First name"required /><br/>
				<input type="textt" name="last-name" placeholder="Last bame"required /><br/>
				<input type="email" name="email"  placeholder="Email" required /><br/>
				<input type="tel" name="phone-number" placeholder="Phone Number" required /><br/>
				<label for="female">Female</label>
				<input type="radio" name="sex" value="female" id="female"/>
				<label for="male">Male</label>
				<input type="radio" name="sex" value="male" id="male"/><br/>
				<span>Birth Date</span><br/>
				<input type="date" name="birthday"/><br/>
				<span>Nationality</span><br/>
				<select name="natioanlity">
					<option value="default" disabled selected>-Natioanlity-</option>
					<option value="Bulgarian">Bulgarian</option>
					<option value="Indian">Indian</option>
					<option value="Arabian">Arabian</option>
					<option value="Turkish">Turkish</option>
				</select>			
			</fieldset>
			<fieldset style="width: 520px;">
				<legend>Last Work Position</legend>
				Company name: <input type="text" name="company" /><br/>
				From <input type="date" name="start-date" /><br/>
				To <input type="date" name="end-date" />
			</fieldset>
			<fieldset style="width: 520px;">
				<legend>Computer Skills</legend>
				<span>Programming Languages</span>
				<div id="progr-lang">
					<!-- HERE WE ADD NEW LANGS BY CALLING THE JS FUNCTION addProgrlang()-->
				</div>
				<script>addProgrlang();</script>
				<input type="button" name="remove-PRlang" value="Remove Language" onclick="removeProgrLang()"/>
				<input type="button" name="add-PRlang[]" value="Add Language" onclick="addProgrlang()"/>
			</fieldset>
			<fieldset style="width: 520px;">
				<legend>Other Skills</legend>
				<span>Languages</span>
				<div id="langs">
					<!-- HERE WE ADD NEW LANGS BY CALLING THE JS FUNCTION addLang()-->
				</div>
				<script>addLang();</script>
				<input type="button" name="add-lang" value="Remove Language" onclick="removeLang()"/>
				<input type="button" name="remove-lang" value="Add Language" onclick="addLang()"/><br />
				<span>Dirver's License</span><br/>
				<label for="b">B</label>
				<input type="checkbox" name="Acategory" value="B" id="b"/>
				<label for="a">A</label>
				<input type="checkbox" name="Bcategory" value="A" id="a"/>
				<label for="c">C</label>
				<input type="checkbox" name="Ccategory" value="C" id="c"/>
			</fieldset>	
			<input type="submit" name="submit" value="Generate CV" />
		</form><br/>
					   
		<?php	
		// check if all data is submitted
		if( (isset($_POST['submit'])) && (isset($_POST['first-name'])) && (isset($_POST['last-name'])) && (isset($_POST['email'])) 
		&& (isset($_POST['phone-number'])) && (isset($_POST['sex'])) && (isset($_POST['birthday'])) && (isset($_POST['natioanlity'])) 
		&& (isset($_POST['company'])) && (isset($_POST['start-date'])) && (isset($_POST['end-date'])) && (isset($_POST['program-langs']))
		&& (isset($_POST['comprehension'])) && (isset($_POST['level'])) && (isset($_POST['langs'])) && (isset($_POST['reading'])) 
		&& (isset($_POST['writing'])) ) {
			  // retrieve data from $_POST[];
			  //personal info
			  $first_name = $_POST['first-name'];
              $last_name = $_POST['last-name'];
		      $email = $_POST['email'];
		      $phone_number = $_POST['phone-number'];
			  $date = $_POST['birthday'];
			  $gender = $_POST['sex'];
			  $natioanlity = $_POST['natioanlity'];
			  //working experience
			  $company = $_POST['company'];
			  $start_date = $_POST['start-date'];
			  $end_date = $_POST['end-date'];
			  //computer skills
			  $program_langs = $_POST['program-langs'];
			  $level = $_POST['level'];
			  //other skills
			  $langs = $_POST['langs'];
			  $comprehension = $_POST['comprehension'];
			  $reading = $_POST['reading'];
			  $writing = $_POST['writing'];
			  //driving license
			  $categories = array();			  
			  if(isset($_POST['Acategory']) )  {
			  	array_push($categories,$_POST['Acategory']);
			  }
			  if(isset($_POST['Bcategory']) )  {
			  	array_push($categories,$_POST['Bcategory']);
			  }
			  if(isset($_POST['Bcategory']) )  {
			  	array_push($categories,$_POST['Ccategory']);
			  }
			  $driving_license = implode(", ", $categories);
			  
			  //create personal info table
			  $personal_info_table = " <table class=\"info\">".
									    	"<thead>".
									    		"<tr>".
									    			"<th colspan=\"2\">Personal information</th>".
									    		"</tr>".
									    	"</thead>".
									    	"<tbody>".
									    		"<tr>".
									    			"<td>First Name</td>".
									    			"<td>$first_name</td>".
									    		"</tr>".
									    		"<tr>".
									    			"<td>Last Name</td>".
									    			"<td>$last_name</td>".
									    		"</tr>".
									    		"<tr>".
									    			"<td>Email</td>".
									    			"<td>$email</td>".
									    		"</tr>".
									    		"<tr>".
									    			"<td>Phone Number</td>".
									    			"<td>$phone_number</td>".
									    		"</tr>".
									    		"<tr>".
									    			"<td>Gender</td>".
									    			"<td>$date</td>".
									    		"</tr>".
									    		"<tr>".
									    			"<td>Birth Date</td>".
									    			"<td>$gender</td>".
									    		"</tr>".
									    		"<tr>".
									    			"<td>Nationalit</td>".
									    			"<td>$natioanlity</td>".
									    		"</tr>".
									    	"</tbody>".
									    "</table>";
             
			 //create last job table
			  $last_job_table = " <table class=\"info\">".
									    	"<thead>".
									    		"<tr>".
									    			"<th colspan=\"2\">Last Work Position</th>".
									    		"</tr>".
									    	"</thead>".
									    	"<tbody>".
									    		"<tr>".
									    			"<td>Company Name</td>".
									    			"<td>$company</td>".
									    		"</tr>".
									    		"<tr>".
									    			"<td>From</td>".
									    			"<td>$start_date</td>".
									    		"</tr>".
									    		"<tr>".
									    			"<td>To</td>".
									    			"<td>$end_date</td>".
									    		"</tr>".									 
									    	"</tbody>".
									    "</table>";
										
			 //create computer skills table
			  $computer_skills_table = " <table class=\"info\">".
									    	"<thead>".
									    		"<tr>".
									    			"<th colspan=\"2\">Computer Skills</th>".
									    		"</tr>".
									    	"</thead>".
									    	"<tbody>".
									    		"<tr>".
									    			"<td>Programming Languages</td>".
									    			"<td>".
										    			"<table class=\"info\">".
											    			"<thead>".
													    		"<tr>".
													    			"<th>Language</th>".
													    			"<th>Skill Level</th>".
													    		"</tr>".
													    	"</thead>".	
													    		"<tbody>";
			for ($i=0; $i < count($program_langs) ; $i++) { 

				$computer_skills_table  .= "<tr>".
											  	"<td>".$program_langs[$i]."</td>".
					                           	"<td>".$level[$i]."</td>".
				                           	"</tr>";
			};													
																
																
				$computer_skills_table .= "</tbody>";							
						    			"</table>".
					    			"</td>".
					    		"</tr>".									 
					    	"</tbody>".
					    "</table>";	
			
			 //create other skills table
			  $other_skills_table = " <table class=\"info\">".
									    	"<thead>".
									    		"<tr>".
									    			"<th colspan=\"2\">Other Skills</th>".
									    		"</tr>".
									    	"</thead>".
									    	"<tbody>".
									    		"<tr>".
									    			"<td>Languages</td>".
									    			"<td>".
										    			"<table class=\"info\">".
											    			"<thead>".
													    		"<tr>".
													    			"<th>Language</th>".
													    			"<th>Comprehension</th>".
													    			"<th>Reading</th>".
													    			"<th>Writing</th>".
													    		"</tr>".
													    	"</thead>".	
													    		"<tbody>";
			for ($i=0; $i < count($langs) ; $i++) { 

				$other_skills_table .= "<tr>".
										  	"<td>".$langs[$i]."</td>".
				                           	"<td>".$comprehension[$i]."</td>".
				                           	"<td>".$reading[$i]."</td>".
				                           	"<td>".$writing[$i]."</td>".					                
			                           "</tr>";
			};													
																
																
				$other_skills_table .= "</tbody>";							
						    			"</table>".
					    			"</td>".
					    		"</tr>".
					    		"<tr>".
					    			"<td>Driver's License</td>"/
					    			"<td>".$driving_license."</td>".
					            "<tr>".  										 
					    	"</tbody>".
					    "</table>";											
						

			  
			  
			  
			  
				// Check first name
			 if( (!preg_match('/[^A-Za-z]/',$_POST['first-name'])) && (strlen($_POST['first-name']) > 2)
			  && (strlen($_POST['first-name']) < 20) ){

			  }		
	            // check last name
	         if( (!preg_match('/[^A-Za-z]/',$_POST['last-name'])) && (strlen($_POST['last-name']) > 2)
			  && (strlen($_POST['last-name']) < 20) ){
			  }	
	            // check email
			if(filter_var($_POST['email'],FILTER_VALIDATE_EMAIL)){

			  }
			   // check phone number
			if( (!preg_match('/[^0-9\+\-\s]/', $_POST['phone-number']) ) ){
			}


			echo "<div id=\"CV\">".
					"<h1>CV</h1>".
					$personal_info_table.
					"<br/>".
					$last_job_table.
					"<br/>".
					$computer_skills_table.
					"<br/>".
					$other_skills_table.
				"</div>";		
					
				
			
			
		}	
		
		?>		
	</body>
</html>
