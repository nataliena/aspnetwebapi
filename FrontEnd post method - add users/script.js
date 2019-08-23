
  $( "#submitBtn" ).click(function() {
    let firstName=$("#firstName").val();
    console.log(firstName)
    let lastName=$("#lastName").val();
    let age=$("#age").val();
    postdata(firstName,lastName,age)

  });
 
async function postdata(x,y,z)
 {
    const rawResponse = await fetch('http://localhost:52621/api/users', {
      method: 'POST',
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({FirstName:x, LastName: y, Age:z})
      
    });
    
    const content = await rawResponse.json();
   
    console.log(content);
  };