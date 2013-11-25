$(document).ready(function () {



















    var output = "";

    var filename = "";
    var pname = "";
    var jawwal = "";
    var email = "";
    var doctor = "";


    $.ajax({
        contentType: 'application/json; charset=utf-8',
        data: '',
        url: "../api/Doctor",
        type: "GET",
        crossDomain: true,
        headers: { 'X-Requested-With': 'XMLHttpRequest' },
        success: function (data) {
            //alert(data);
            //var x=JSON.parse(data);//convert string to json object


            $.each(data, function (index, item) {




                if (index == 2) {
                    output = output +
    "<option jsondata='" + JSON.stringify(item) + "'" +
                    
                    "selected value='" + item.Id + "'>" + item.Name + "</option>";

                }
                else
                {
                    output = output +
"<option jsondata='" + JSON.stringify(item) + "'" +

                    " value='" + item.Id + "'>" + item.Name + "</option>";

                }




            });
            $('#select').html(output);
           // alert(output);
        }

    });








    $('.appointment-submitter').click(function () {

        
        
        
        
        

        var filename = $('.filename').val();
        var pname = $('.patientname').val();
        var jawwal = $('.jawwal').val();
        var email = $('.email').val();

        var selectedDoctor = $('.doctorslected').find('option:selected');
        var doctor = selectedDoctor.attr("jsondata");
        doctor = JSON.parse(doctor);

       // alert(doctor);

        console.log(filename + pname + jawwal + email + doctor);

        var data = {
            "Doctor": doctor,
            "FileNumber": filename,
            "PatientName": pname,
            "PatientEmail": email,
            "PatientPhone": jawwal,
            "DoctorId": doctor.Id
        };

  


        $.ajax({
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(data),
            url: "../api/Appointment",
            type: "POST",
            crossDomain: true,
            headers: { 'X-Requested-With': 'XMLHttpRequest' },
            success: function (data) {
                alert(data.PatientName + " is inserted");
               

             
               
            }

        });












    });


});