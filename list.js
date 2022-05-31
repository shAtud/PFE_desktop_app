const adminForm=document.getElementById('adminForm');
const{remote}=require('electron')
const main=remote.require('main.js')
const adminfirstname=document.getElementById('firstname');
const adminlastname=document.getElementById('lastname');
const adminemail=document.getElementById('email');
const adminslist=document.getElementById('admins')
let admins=[]

adminForm.addEventListener('submit',async(e)=>{
    e.preventDefault();
    const newadmin={
        firstname:adminfirstname.value,
    lastname:adminlastname.value,
    email:adminemail.value

    }
  const result= await main.createAdmin(newadmin);
  console.log(result);

    
})
function deleteAdmin(id){
    const reponse=confirm('are you sure you want to delete it ')
    if (reponse){
 await main.deleteAdmin(id)
    getAdmins();}
return;
}
async function editAdmin(id){
    
}
function renderAdmins(admins){
    adminslist.innerHTML='';
    admins.forEach(admin => {
        adminslist.innerHTML +=
        <div class="card card-body my-2"> 
        <h2>${admin.firstname}</h2>
        <h2>${admin.lastname}</h2>
        <h2>${admin.email}</h2>
        <p>
            <button class="btn btn-danger" onclick='deleteAdmin("${admin.id}")'>delete</button>
            <button class="btn btn-secondary">edit</button>
        </p>
        
        </div>;
        
    });

}
const getAdmins= async()=>{
    admins=await main.getAdmins();
    renderAdmins(admins);


}
async function init(){
    await getAdmins();
}
init();

getAdmins();
deleteAdmin();
