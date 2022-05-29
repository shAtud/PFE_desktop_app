const { app, BrowserWindow, ipcMain, Notification } = require('electron');
const path = require('path'); 
let db = require('./database')


var mysql = require('mysql');

var con = mysql.createConnection({
  host: "localhost",
  port:"3307",
  user: "root",
  password: "",
  database: "login"
});


con.connect(function(err) {
  if (err) throw err;

});

let win;
let winlogin;
function createWindow () {
   win = new BrowserWindow({
    width: 800,
    height: 600,
    webPreferences: {
     // nodeIntegration: true,
     // contextIsolation:true,
     // devTools:false,
      //preload:path.join(__dirname, 'index.js')
      
    }
  })

  win.loadFile('screen.html')
}

function loginWindow () {
  winlogin = new BrowserWindow({
   width: 800,
   height: 600,
   webPreferences: {
    // nodeIntegration: true,
    // contextIsolation:true,
    // devTools:false,
     preload:path.join(__dirname, 'login.js')
     
   }
 })

 winlogin.loadFile('login.html')
}



app.whenReady().then(loginWindow)

app.on('window-all-closed', () => {
  if (process.platform !== 'darwin') {
    app.quit()
  }
})

app.on('activate', () => {
  if (BrowserWindow.getAllWindows().length === 0) {
    createWindow()
  }
})

ipcMain.handle('login', (event, obj) => {
  validatelogin(obj)
});


function validatelogin(obj) {

 
    const {username, password } = obj 
    const sql = "SELECT * FROM user WHERE username=? AND password=?"
   
     con.query(sql, [username, password],function (err, result, fields)  {
   
       if(err){ console.log(err);}
   
       console.log(result.length);
   
       if(result.length > 0){
          createWindow ()
          win.show()
          winlogin.close()
        }else{
   
   
          new Notification({
            title:"login",
            body: 'wrong email or password!'
          }).show()
        }
       
     });
  

  
}


