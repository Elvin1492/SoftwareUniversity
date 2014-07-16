function evalExppression() {
    var input = document.getElementById('input_expression').value;
    var result = eval(input);
    document.getElementById('result').innerHTML = result;

}