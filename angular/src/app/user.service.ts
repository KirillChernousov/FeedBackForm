import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';


@Injectable({
  providedIn: 'root'
})

export class UserService {
readonly APIUrl = "https://localhost:5001/api";

  constructor(private http:HttpClient) { }

  addMessage(val:any){
    return this.http.post(this.APIUrl+'/TMessages', val)
  }

  // getMessages():Observable<any[]>{
  //    return this.http.get<any>(this.APIUrl+'/TMessages');
  //  }
  //  addMessage(val:any){
  //   return this.http.post(this.APIUrl+'/TMessages', val)
  // }
  // updateMessage(val:any){
  //   return this.http.put(this.APIUrl+'/TMessages', val)
  //  }
  // deleteMessage(val:any){
  //   return this.http.delete(this.APIUrl+'/TMessages/' + val)
  // }

  // getContacts():Observable<any[]>{
  //   return this.http.get<any>(this.APIUrl+'/Contacts');
  // }
  // addContact(val:any){
  //   return this.http.post(this.APIUrl+'/Contacts', val)
  // }
  // updateContact(val:any){
  //   return this.http.put(this.APIUrl+'/Contacts', val)
  // }
  // deleteContact(val:any){
  //   return this.http.delete(this.APIUrl+'/Contacts/' + val)
  // }

  // getTopics():Observable<any[]>{
  //   return this.http.get<any>(this.APIUrl+'/Topics');
  // }
  // addTopic(val:any){
  //   return this.http.post(this.APIUrl+'/Topics', val)
  // }
  // updateTopic(val:any){
  //   return this.http.put(this.APIUrl+'/Topics', val)
  // }
  // deleteTopic(val:any){
  //   return this.http.delete(this.APIUrl+'/Topics/' + val)
  // }
  // getAllMessagesInfo():Observable<any[]>{
  //   return this.http.get<any>(this.APIUrl+'/TMessages/GetAllMessagesInfo');
  // }
}
