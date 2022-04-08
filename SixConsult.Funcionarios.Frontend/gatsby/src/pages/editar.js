import * as React from 'react';
import Layout from '../components/Layout';
import { useForm } from 'react-hook-form';
import {
  Box,
  Button,
  FormControl,
  FormControlLabel,
  FormLabel,
  Radio,
  RadioGroup,
  TextField,
} from '@mui/material';
import { navigate } from 'gatsby';

export default function Editar(props) {
  const {
    handleSubmit,
    register,
    reset,
    formState: { errors },
  } = useForm();

  const [valueRadio, setValueRadio] = React.useState('celular');

  const handleChange = (event) => {
    setValueRadio(event.target.value);
  };

  const { data } = props.location.state;

  React.useEffect(() => {
    setTimeout(() => {
      reset({
        nome: data.nome,
        sobrenome: data.sobrenome,
        email: data.email,
        numeroChapa: data.numeroChapa,
        lider: data.lider,
        senha: data.senha,
      });
    });
  }, [reset, data]);

  const onSubmit = async (dataForm) => {
    const { nome, sobrenome, email, numeroChapa, senha } = dataForm;

    var FormattedData = {
      nome: nome,
      sobrenome: sobrenome,
      email: email,
      numeroChapa: numeroChapa,
      senha: senha,
      telefones: [],
    };

    console.log(data.id);

    await fetch(`https://localhost:5001/funcionario/${data.id}`, {
      method: 'put',
      headers: {
        'Content-Type': 'application/json',
      },

      body: JSON.stringify(FormattedData),
    })
      .then((msg) => {
        console.log('mensagem:' + JSON.stringify(msg));
      })
      .catch((error) => {
        console.log(error);
      });
  };

  return (
    <Layout>
      <h1>Editar Funcionário</h1>
      <form onSubmit={handleSubmit(onSubmit)}>
        <TextField
          id="nome"
          label="Nome"
          variant="outlined"
          margin="normal"
          fullWidth
          {...register('nome')}
        />
        {errors.nome && <span>Campo Obrigatório</span>}
        <TextField
          id="sobrenome"
          label="Sobrenome"
          variant="outlined"
          margin="normal"
          fullWidth
          {...register('sobrenome', { required: true })}
        />
        {errors.sobrenome && <span>Campo Obrigatório</span>}
        <TextField
          id="email"
          label="Email"
          type={'email'}
          variant="outlined"
          margin="normal"
          fullWidth
          {...register('email', { required: true })}
        />
        {errors.email && <span>Campo Obrigatório</span>}
        <TextField
          id="numeroChapa"
          label="Número da chapa"
          variant="outlined"
          margin="normal"
          fullWidth
          {...register('numeroChapa', { required: true })}
        />
        {errors.numeroChapa && <span>Campo Obrigatório</span>}
        <TextField
          id="lider"
          label="Lider"
          variant="outlined"
          margin="normal"
          fullWidth
          {...register('Lider', { required: true })}
        />
        {errors.Lider && <span>Campo Obrigatório</span>}
        <TextField
          id="senha"
          label="Senha"
          type={'password'}
          variant="outlined"
          margin="normal"
          fullWidth
          {...register('senha', { required: true })}
        />
        {errors.senha && <span>Campo Obrigatório</span>}

        <Box
          sx={{
            '& > :not(style)': { m: 1, width: '25ch' },
          }}
          noValidate
          autoComplete="off"
        >
          <TextField
            style={{ width: '10ch' }}
            id="dddTelefone"
            label="DDD"
            variant="outlined"
            margin="normal"
            {...register('dddTelefone', { required: true })}
          />
          <TextField
            id="numeroTelefone"
            label="Numero"
            variant="outlined"
            margin="normal"
            {...register('Numero', { required: true })}
          />
          <FormControl>
            <FormLabel id="buttons-group-label">Tipo</FormLabel>
            <RadioGroup
              row
              aria-labelledby="buttons-group-label"
              name="row-radio-buttons-group"
              value={valueRadio}
              onChange={handleChange}
            >
              <FormControlLabel
                value="Celular"
                control={<Radio />}
                label="Celular"
              />
              <FormControlLabel value="Fixo" control={<Radio />} label="Fixo" />
            </RadioGroup>
          </FormControl>
        </Box>
        <Button
          variant="contained"
          size="large"
          style={{ marginBottom: '20px', marginTop: '20px', width: '40ch' }}
          fullWidth
          onClick={() => {
            alert('clicado');
          }}
        >
          Adicionar Telefone
        </Button>
        <Button
          variant="contained"
          size="large"
          style={{ marginBottom: '20px', marginTop: '20px' }}
          fullWidth
          // onClick={() => {
          //   ActionOnSumit();
          // }}
          type="submit"
        >
          Enviar
        </Button>
        <Button
          variant="outlined"
          size="large"
          fullWidth
          onClick={() => {
            navigate('/listagem');
          }}
        >
          Cancelar
        </Button>
      </form>
    </Layout>
  );
}
