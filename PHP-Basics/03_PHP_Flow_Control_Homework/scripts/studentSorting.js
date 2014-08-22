var nextID = 0;		
		function addStudent(){
			nextID ++;
			var inputROW = document.createElement("tr");
			inputROW.setAttribute("id","num" + nextID);
			inputROW.innerHTML =
				"<td><input type=\"text\" name=\"firstName[]\"placeholder=\"Enter first name\" /></td>" +
				"<td><input type=\"text\" name=\"lastName[]\"placeholder=\"Enter last name\"d /></td>	" +
				"<td><input type=\"email\" name=\"email[]\"placeholder=\"Enter emali\" /></td>" +
				"<td><input type=\"number\" name=\"score[]\"placeholder=\"Enter score\" />" +
				"<input type=\"button\" name=\"remove\" value=\"Remove\"onclick=\"removeStudent()\"/></td>";
			document.getElementById("students").appendChild(inputROW);
		};
		
		function removeStudent(){
			var removeROW = document.getElementById("students").lastChild;
			document.getElementById("students").removeChild(removeROW);
		};