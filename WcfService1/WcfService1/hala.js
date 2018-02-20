$(document).ready(function () {
    $.ajax({
        url: "http://localhost:54449/Service1.svc/hlist"
    }).then(function (data) {
        var t = document.getElementById('tabela2');
        var wiersze = data.GetHListResult.split("#");
        for (i = 0; i < wiersze.length - 1; i++) {
            var pole = wiersze[i].split("|");
            var il = t.getElementsByTagName('tr').length;
            var row = t.insertRow(il);
            var cell1 = row.insertCell(0);
            var cell2 = row.insertCell(1);
            var cell3 = row.insertCell(2);
            cell1.innerHTML = pole[0];
            cell2.innerHTML = pole[1];
            cell3.innerHTML = pole[2];
        }
    });
});