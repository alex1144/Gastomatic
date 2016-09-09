// Here we will create react component for generate form with validation

//React component for input component
var MyInput = React.createClass({
    //onchange event
    handleChange: function (e) {
        this.props.onChange(e.target.value);
        var isValidField = this.isValid(e.target);
    },
    //validation function
    isValid: function (input) {
        //check required field
        if (input.getAttribute('required') != null && input.value ==="") {
            input.classList.add('error'); //add class error
            input.nextSibling.textContent = this.props.messageRequired; // show error message
            return false;
        }
        else {
            input.classList.remove('error'); 
            input.nextSibling.textContent = ""; 
        }
        return true;
    },
    componentDidMount: function () {
        if (this.props.onComponentMounted) {
            this.props.onComponentMounted(this); //register this input in the form
        }
    },    
    //render
    render: function () {
        var inputField;
        inputField = <input type={this.props.type} value={this.props.value} ref={this.props.name} name={this.props.name}
        className='form-control' required={this.props.isrequired} onChange={this.handleChange} />
        return (
                <div className="form-group">
                    <label htmlFor={this.props.htmlFor}>{this.props.label}:</label>
                    {inputField}
                    <span className="error"></span>
                </div>
            );
    }
});
//React component for generate form

var ContactForm = React.createClass({
    //get initial state enent
    getInitialState : function(){
        return {
            Nombre : '',
            Descripcion:'',
            Fields : [],
            ServerMessage : ''
        }
    },
    // submit function
    handleSubmit : function(e){
        e.preventDefault();
        //Validate entire form here
        var validForm = true;
        this.state.Fields.forEach(function(field){
            if (typeof field.isValid === "function") {
                var validField = field.isValid(field.refs[field.props.name]);
                validForm = validForm && validField;
            }
        });
        //after validation complete post to server 
        if (validForm) {
            var d = {
                Nombre: this.state.Nombre,
                Descripcion : this.state.Descripcion
            }

            $.ajax({
                type:"POST",
                url : this.props.urlPost,
                data : d,
                success: function(data){
                    //Will clear form here
                    this.setState({
                        Nombre : '',
                        Descripcion  : '',
                        ServerMessage: data.message
                    });
                }.bind(this),                
                error : function(e){
                    console.log(e);
                    alert('Error! Please try again');
                }
            });
        }
    },
    //handle change full name
    onChangeNombre : function(value){
        this.setState({
            Nombre : value
        });
    },
    //handle chnage email
    onChangeDescripcion : function(value){
        this.setState({
            Descripcion : value
        });
    },
    //register input controls
    register : function(field){
        var s = this.state.Fields;
        s.push(field);
        this.setState({
            Fields : s
        })
    },
    //render
    render : function(){
        //Render form 
        return(
            <form name="contactForm" noValidate onSubmit={this.handleSubmit}>
                <MyInput type={'text'} value={this.state.Nombre} label={'Nombre'} name={'Nombre'} htmlFor={'Nombre'} isrequired={true}
                    onChange={this.onChangeNombre} onComponentMounted={this.register} messageRequired={'Nombre required'} />
                <MyInput type={'text'} value={this.state.Descripcion} label={'Descripcion'} name={'Descripcion'} htmlFor={'Descripcion'} isrequired={false}
                    onChange={this.onChangeDescripcion} onComponentMounted={this.register} messageRequired={'Invalid Descripcion'} />
                <button type="submit" className="btn btn-default">Submit</button> 
                <p className="servermessage">{this.state.ServerMessage}</p>
            </form>
        );
    }
});

//Render react component into the page
        ReactDOM.render(<ContactForm urlPost="/Conceptos/SaveCreate" />, document.getElementById('contactFormArea'));