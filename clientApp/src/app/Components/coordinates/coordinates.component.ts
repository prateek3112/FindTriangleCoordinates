import { Component, OnInit } from '@angular/core';
import { DataService } from '../../Service/data.service';
import { FormGroup, FormControl, Validators} from '@angular/forms';
import Swal from 'sweetalert2'
@Component({
  selector: 'app-coordinates',
  templateUrl: './coordinates.component.html',
  styleUrls: ['./coordinates.component.css']
})
export class CoordinatesComponent implements OnInit {

  Row: any = ['A', 'B', 'C', 'D', 'E', 'F'];
  Col: any = [1,2,3,4,5,6,7,8,9,10,11,12]
  data:any;
  constructor(private _data : DataService) { }

  ngOnInit(): void {
  }


  form = new FormGroup({
    RowSelected: new FormControl('', Validators.required),
    ColSelected: new FormControl('', Validators.required)
  });
  
  get f(){
    return this.form.controls;
  }
  
  async submit(){
    
    await this._data.getdata(this.form.value).then(data => 
      
      {
        this.data = data;
        
      }).catch(err=>{
        if(err.status == 400 || err.status== 500){
          alert("Please Check the Coordinates");
        }
      });
  }
  
  change(e) {
    console.log(e.target.value);
  }


}
