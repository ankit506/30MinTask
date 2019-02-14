var sign = "X";
var sign ="o";
var disp = document.getElementById("player");
var play;
var count=0;
var Email;
var Pass;


function printx(number){
    var play = document.getElementById("r"+number);
  console.log(play);
  
  if(play.innerText==""){
  play.innerText=sign;
  winner();
  match();
 disp.innerHTML="<center>"+ sign + " Turn "+"</center>";
 
  }
  
  
}
function match(){
    if(sign=="x")sign ="o";
    else sign = "x";
   
}
function notmatch(no){
    return document.getElementById("r"+no).innerHTML;
}
function checkmove(a,b,c,m){
    if(notmatch(a)==m && notmatch(b)==m && notmatch(c)==m)
       return true;
    else return false;   
}

function winner(){
if(checkmove(1,2,3,sign)||checkmove(4,5,6,sign)||checkmove(7,8,9,sign)
    ||checkmove(1,4,7,sign)||checkmove(2,5,8,sign)||checkmove(3,6,9,sign)
    ||checkmove(1,5,9,sign)||checkmove(7,5,3,sign)){
    disp.innerHTML = "<center>" +sign + " Won " + "</center>";
    for(var i=1;i<=9;i++){
        document.getElementById("r"+i).innerHTML="";
    }
    if(sign=="X"){
    count=count+10;
    }
    else
        count=count-5;
    alert("score updated")
    console.log(count);
   throw "game end";
}else{
    if(notmatch(1)!=""&& notmatch(2)!=""&& notmatch(3)!=""&&
   notmatch(4)!=""&& notmatch(5)!=""&& notmatch(6)!=""&&
   notmatch(7)!=""&& notmatch(8)!=""&& notmatch(9)!=""){

    disp.innerHTML = "<center> its a tie </center>";

        alert("score updated")
       throw "its a tie";
   }
}
}
