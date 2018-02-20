$(document).ready(function () {
    $.ajax({
        url: "http://localhost:54449/Service1.svc/slist"
    }).then(function (data) {
        var t = document.getElementById('tabela');
        var wiersze = data.GetSListResult.split("#");
        for (i = 0; i < wiersze.length - 1; i++) {
            var pole = wiersze[i].split("|");
            var il = t.getElementsByTagName('tr').length;
            var row = t.insertRow(il);
            row.id = 'rowId_' + pole[0];
            var cell1 = row.insertCell(0);
            var cell2 = row.insertCell(1);
            var cell3 = row.insertCell(2);
            var cell4 = row.insertCell(3);
            var cell5 = row.insertCell(4);
            var cell6 = row.insertCell(5);
            var cell7 = row.insertCell(6);
            cell1.innerHTML = pole[0];
            cell2.innerHTML = pole[1];
            cell3.innerHTML = pole[2];
            cell4.innerHTML = pole[3];
            cell5.innerHTML = pole[4];
            cell6.innerHTML = pole[5];
            cell7.innerHTML = pole[6];
        }
    });
});

function deleteSiatkarz() {
    const id = $('#txtId').val();
    $.ajax({
        url: "http://localhost:54449/Service1.svc/deletesiatkarz/" + id,
        type: "POST"
    }).then(function (data) {
        var r = document.getElementById('rowId_' + id).rowIndex;
        document.getElementById('tabela').deleteRow(r);
    });
}