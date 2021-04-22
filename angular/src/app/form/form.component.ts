import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import {UserService} from 'src/app/user.service'


@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})

export class FormComponent {

  
  form = this.fb.group
    (
      {
        name: ['', Validators.required],
        email: ['', [ Validators.required, Validators.email]],
        phone: ['', Validators.required],
        topic: [''],
        message: ['', Validators.required],
      }
    );
    
  constructor(private fb: FormBuilder, private service:UserService) { }
  
  @Input() mes:any;
  name1:string = '';
  email1:string = '';
  phone1:string = '';
  topic1:string = '';
  message1:string = '';
  
  onSubmit() {

    if((document.getElementById('captcha') as HTMLInputElement).value == 'qGphJ')
    {      
      var val = {
        contact:this.name1,
        email:this.email1,
        phone:this.phone1,
        messageText:this.message1,
        topic:this.topic1
      }
      this.service.addMessage(val).subscribe(res=>{
        alert(res.toString())
      });
    }
    else
    {
      alert('Неправильно введена капча')
    }
    return;
  }

}
