function checkUser() {
	var myHeaders = new Headers();
myHeaders.append("Content-Type", "application/json");

var raw = JSON.stringify({
  "username": "lagnesh",
  "userPassword": "123"
});

var requestOptions = {
  method: 'POST',
  headers: myHeaders,
  body: raw,
  redirect: 'follow'
};

fetch("http://localhost:54266/api/login", requestOptions)
  .then(response => response.text())
  .then(result => showstorage(result))
  .catch(error => console.log('error', error));
	
}
function showstorage(data)

{

if(data!=null && data!=undefined && data!="")

{  

    console.log(data);

    sessionStorage.setItem("token",data);

    // sessionStorage.setItem("id",data.id);

}

loc();



}

function loc()

{

if(sessionStorage.getItem("token")!=null)

{

window.location.href="dashboard.html";



}

else



{



alert("Login Credentials are wrong");



}



}
 