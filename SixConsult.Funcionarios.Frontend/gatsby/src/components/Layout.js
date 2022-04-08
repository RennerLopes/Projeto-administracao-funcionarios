import { Container } from '@mui/material';
import React from 'react';
import Header from './Header';

export default function Layout({ children }) {
  return (
    <div>
      <Header />
      <Container maxWidth="xl">{children}</Container>
    </div>
  );
}
