import { Injectable } from '@angular/core';
import { InMemoryDbService } from 'angular-in-memory-web-api';
import { Task } from '../models/task';


@Injectable({
  providedIn: 'root',
})
export class InMemoryDataService implements InMemoryDbService {
  createDb() {
    const Task = [
      { id: 11,title:"Wolverine",description:"Marvel",priority:true },
      { id: 12,title:"Superman",description:"Dc",priority:true },
      { id: 13,title:"Batman",description:"Dc",priority:false },
      { id: 14,title:"Iron-man",description:"Marvel",priority:true },

    ];
    return {Task};
  }

  // Overrides the genId method to ensure that a hero always has an id.
  // If the heroes array is empty,
  // the method below returns the initial number (11).
  // if the heroes array is not empty, the method below returns the highest
  // hero id + 1.
  genId(tasks:Task[]):number{
    return tasks.length > 0?Math.max(...tasks.map(task=>task.id)) +1:11;
  }

  
}



