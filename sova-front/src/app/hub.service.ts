import { Injectable, OnInit } from '@angular/core';
import * as signalR from '@aspnet/signalr';

import { environment } from 'environments/environment';

import { Message } from './models/message';

@Injectable({
  providedIn: 'root',
})
export class HubService {
  private connection: signalR.HubConnection;
  public messages: Message[] = [];

  constructor() {
    console.log('ctr');
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl(environment.hubUrl)
      .configureLogging(signalR.LogLevel.Trace)
      .build();

    this.connection.start().then(() => { console.log('start'); }).catch((err) => { document.write(err); });

    this.connection.on('messages', (messages: Message[]) => { this.messages.push(...messages); });

    this.connection.on('newMessage', (message: any) => { this.messages.unshift(message); });

    this.connection.onclose(() => console.log('closed'));
  }
}
